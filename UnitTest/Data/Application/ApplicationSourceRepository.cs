using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Data.Application
{
    public sealed class ApplicationSourceRepository
    {
        public const string CROME_TEMPORARY = "ChromeTemporary";
        public const string CROME_TEMPORARY_MAXIMIZED = "ChromeTemporaryMaximized";
        public const string CROME_TEMPORARY_WITHOUT_UI = "ChromeTemporaryWithoutUI";

        private ApplicationSourceRepository() { }

        public static ApplicationSource Default()
        {
            return ChromeTemporaryWordpress();
        }
        public static ApplicationSource ChromeTemporaryWordpress()
        {
            return new ApplicationSource(CROME_TEMPORARY, 10L, 10L,
                "http://demosite.center/wordpress/wp-login.php",
                "http://demosite.center/wordpress/wp-login.php?action=logout&_wpnonce=38a471b495");
        }
        public static ApplicationSource ChromeTemporaryMaximizedWordpress()
        {
            return new ApplicationSource(CROME_TEMPORARY_MAXIMIZED, 10L, 10L,
                "http://demosite.center/wordpress/wp-login.php",
                "http://demosite.center/wordpress/wp-login.php?action=logout&_wpnonce=38a471b495");
        }
        public static ApplicationSource ChromeWithoutUIWordpress()
        {
            return new ApplicationSource(CROME_TEMPORARY_WITHOUT_UI, 10L, 10L,
                "http://demosite.center/wordpress/wp-login.php",
                "http://demosite.center/wordpress/wp-login.php?action=logout&_wpnonce=38a471b495");
        }
    }
}
