
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;
using PaymentGateWay.Core.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using PaymentGateWay.Core;
using PaymentGateWay.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using PaymentGateWay.Core.Entities;
using PaymentGateWay.Api.Auth;
using Microsoft.Extensions.Options;


namespace PaymentGateWay.Services.Services
{
    public partial class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;
        public UserService(IUnitOfWork unitOfWork , IMapper mapper, 
            IJwtFactory jwtFactory,
            IOptions<JwtIssuerOptions> jwtOptions)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<AuthenticationModel> LoginAsync(LoginModel input, CancellationToken ct = default)
        {
           var user  = await _unitOfWork.User.GetByUserNameAsync(input.LoginName);
            if (user == null)
                return null;                     
            if (!VerifyPasswordHash(input.Password, user.Password))
                return null;
            var token = await generateJwtTokenAsync(user, _jwtFactory, _jwtOptions);
            var newRefreshToken = GenerateRefreshToken();
            // To Add RefreshToken to User Entity
            // user.RefreshToken = newRefreshToken;
            await _unitOfWork.User.UpdateAsync(user);
            var response = new AuthenticationModel
            {
                Id = user.Id,
                LoginName = user.LoginName,
                RefreshToken = newRefreshToken,
                Token = token
            };
             return  response;
        }
        public async Task<string> RefreshToken(RefreshTokenModel Model)
        {
            var principal = _jwtFactory.GetPrincipalFromExpiredToken(Model.Token);
            var loginName = principal.Identity.Name;
            var user = await _unitOfWork.User.GetByUserNameAsync(loginName);
            if (user == null || !user.RefreshToken.Equals(Model.RefreshToken)) return null;
            var newRefreshToken = GenerateRefreshToken();
            var token = await generateJwtTokenAsync(user, _jwtFactory, _jwtOptions);
            user.RefreshToken = newRefreshToken;
            await _unitOfWork.User.UpdateAsync(user);
            return token;
        }
        public async Task<CompanyUserModel> AddCompanyUserAsync(CompanyUserVm input, CancellationToken ct = default)
        {
            var hashed = PasswordEncryption(input.Password, null); ;
            var user = _mapper.Map<User>(input);           
            user.Password = hashed;
            user.UserStatusId = (long)Constant.UserStatus.Pending;
            user = await _unitOfWork.User.AddAsync(user);
            return _mapper.Map<CompanyUserModel>(user);
        }

        public async Task<IndiviualUserModel> AddIndiviualUserAsync(IndiviualUserVm input, CancellationToken ct = default)
        {
            var hashed = PasswordEncryption(input.Password, null); ;
            var user = _mapper.Map<User>(input);
            user.Password = hashed;
            user.UserStatusId =(long) Constant.UserStatus.Pending;
            user = await _unitOfWork.User.AddAsync(user);
            return _mapper.Map<IndiviualUserModel>(user);
        }

        public async Task<CompanyUserModel> GetUserByIdAsync(long id, CancellationToken ct = default)
        {
            var User = await _unitOfWork.User.GetByIdAsync(id);
            return _mapper.Map<CompanyUserModel>(User);
        }
        public async Task<List<CompanyUserModel>> GetAllUsersAsync(UserFilterModel filter , CancellationToken ct = default)
        {
            var users = await _unitOfWork.User.GetAllAsync(ct);
            return _mapper.Map<List<CompanyUserModel>>(users);
        }
        public async Task<CompanyUserModel> UpdateUserAsync(CompanyUserModel input, CancellationToken ct = default)
        {
            var user = await _unitOfWork.User.UpdateAsync(_mapper.Map<User>(input));
            return _mapper.Map<CompanyUserModel>(user);
        }

        public async Task<bool> ApproveUserAsync(long userId, CancellationToken ct = default)
        {
            var user = await _unitOfWork.User.GetByIdAsync(userId, ct);
            user.UserStatusId= (long)Constant.UserStatus.Active;
            user.UpdatedDate = DateTime.Now;
            
              await _unitOfWork.User.UpdateAsync(user,ct);
              return true; 
        }
        public async Task DeleteUserAsync(long id, CancellationToken ct = default)
        {
            await _unitOfWork.User.DeleteAsync(id);
        }
        public async Task<AttachmentModel> UploadBusinessCertificationAsync(long?userId,IFormFile file, CancellationToken ct = default)
        {
            var fileNameAndType = file.FileName.Split('.');
            if (!fileNameAndType[1].Equals("pdf"))
                throw new FormatException("the Attachment type should be pdf");
            var path  =  "\\Attachments\\"+"CompanyAttachments / ";
            DateTime now = DateTime.Now;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
          
            var FileName = fileNameAndType[0] + now.ToString("yyyyMMddHHmmss") + "." + fileNameAndType[1];
            string StoragePath = path + FileName;
            using (var fileStream = new FileStream(StoragePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            var attachment = new Attachment
            {
                PhysicalFileName = FileName,
                OriginalFileName = file.FileName,
                Path = FileName,
                FileType = file.ContentType,
                CreatedDate = now,
                CreatedById = userId,
                UpdatedDate = now,
                UpdatedById = userId
            };

            attachment = await  _unitOfWork.Attachment.AddAsync(attachment,ct);
            AttachmentModel attachmentApiModel = _mapper.Map<AttachmentModel>(attachment);
            return attachmentApiModel;


        }
        private static bool VerifyPasswordHash(string password, string storedHash)
        {
            string[] hash = storedHash.Split(':');
            string salt = hash[0];
            string hashed = hash[1];
            var passwordHash = PasswordEncryption(password, salt);
            if (passwordHash.Equals(storedHash))
                return true;
            else
                return false;
        }
        public static string PasswordEncryption(string password, string _salt)
        {
            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            if (String.IsNullOrEmpty(_salt))
            {
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }
                _salt = Convert.ToBase64String(salt);
            }
            else
            {
                salt = Convert.FromBase64String(_salt);
            }

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            hashed = _salt + ":::" + hashed;
            return hashed;
        }
        private async Task<string> generateJwtTokenAsync(User user, IJwtFactory jwt, JwtIssuerOptions options)
        {
            options.ValidFor = TimeSpan.FromMinutes(120);
            var claimsIdentity = jwt.GenerateClaimsIdentity(user.LoginName, user.Id.ToString());
            var auth_token = await jwt.GenerateEncodedToken(user.LoginName, claimsIdentity);
            return auth_token;
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
        public long? GetUserId(ClaimsPrincipal User)
        {
            try
            {
                if (User.FindFirst("id")?.Value != null)
                {
                    return long.Parse(User.FindFirst("id")?.Value);
                }
            }
            catch (Exception)
            {
                return null;
            }

            return null;
        }

        public async Task<bool> IsAdmin(long? userId)
        {
            if (userId != null)
            {

              var user =await _unitOfWork.User.GetByIdAsync((long) userId);
             return   _ = user.UserTypeId ==(long) Constant.UserType.SystemAdmin;
            }

            return false;
        }

    }
}
