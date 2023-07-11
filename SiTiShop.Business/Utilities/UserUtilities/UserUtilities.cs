using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SiTiShop.Data.Entities;

namespace SiTiShop.Business.Utilities.UserUtilities
{
    public class UserUtilities
    {
        private static string Key = "DuAnSiTiShopTuSiTiGroupDaiHocEpBeTe";
        private static string Issuser = "SiTiShop";

        public static byte[] CreatePasswordHash(string password)
        {
            using (MD5 mh = MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
                byte[] hash = mh.ComputeHash(inputBytes);
                return hash;
            }
        }

        public static bool VerifyPasswordHash(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length)
                return false;

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                    return false;
            }

            return true;
        }

        public static string GenerateJWT(TblUser UserInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,UserInfo.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: Issuser,
                audience: Issuser,
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credential
                );
            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }
    }
}
