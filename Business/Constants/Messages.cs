using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarsListed = "Arabalar listelendi";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string Added = "Eklendi";
        public static string Listed = "Listelendi";
        internal static string? AuthorizationDenied = "Yetkiniz yok";
        internal static string UserRegistered = "Kayıt olundu";
        internal static string UserNotFound = "Kullanıcı bulunamadı";
        internal static string PasswordError = "Şifre hatalı";
        internal static string SuccessfulLogin = "Giriş başarılı";
        internal static string UserAlreadyExists = "Kullanıcı zaten var";
        internal static string AccessTokenCreated = "Erişim token'i oluşturuldu";
    }
}
