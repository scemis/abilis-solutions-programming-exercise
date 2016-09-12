using AbilisSolutions.ProgrammingExercise.Domain;
using System;

namespace AbilisSolutions.ProgrammingExercise.Web
{
    /// <summary>
    /// This class specifies global variables
    /// </summary>
    public static class Global
    {
        #region Keys
        private static string _keyCDN = "CDN";
        private static string _keyBootstrap = "Bootstrap";
        private static string _keyBootstrapSwitch = "BootstrapSwitch";
        private static string _keyJQuery = "JQuery";
        private static string _keyIMG = "IMG";
        private static string _keyJS = "JS";
        private static string _keyCSS = "CSS";

        private static string _keyAuthorName = "AuthorName";
        private static string _keyAuthorEmail = "AuthorEmail";
        private static string _keyAuthorProfile = "AuthorProfile";

        private static string _keyMatrixSize = "MatrixSize";
        private static string _keyMatrixBase = "MatrixBase";
        private static string _keyMatrixMinSize = "MatrixMinSize";
        private static string _keyMatrixMaxSize = "MatrixMaxSize";
        private static string _keyShowPrimeNumbers = "ShowPrimeNumbers";
        #endregion

        #region Default Values
        private static string _defaultCDN = "/_content";
        private static string _defaultBootstrap = "bower_components/bootstrap/dist";
        private static string _defaultBootstrapSwitch = "bower_components/bootstrap-switch/dist";
        private static string _defaultJQuery = "bower_components/jquery/dist";
        private static string _defaultIMG = "images";
        private static string _defaultJS = "scripts";
        private static string _defaultCSS = "styles";

        private static string _defaultAuthorName = "Serghei Cemis";
        private static string _defaultAuthorEmail = "s.cemis@gmail.com";
        private static string _defaultAuthorProfile = "https://ca.linkedin.com/in/scemis";

        private static int _defaultMatrixSize = 10;
        private static Enums.MatrixBase _defaultMatrixBase = Enums.MatrixBase.Decimal;
        private static int _defaultMatrixMinSize = 3;
        private static int _defaultMatrixMaxSize = 15;
        private static bool _defaultMatrixShowPrimeNumbers = true;
        #endregion

        #region Private Content Paths
        private static string _CDN { get { return GetValueFor(_keyCDN, _defaultCDN); } }
        #endregion

        #region Public Content Paths
        /// <summary>
        /// Path to Bootstrap
        /// </summary>
        public static string Bootstrap { get { return GetPathFor(_keyBootstrap, _defaultBootstrap); } }
        /// <summary>
        /// Path to Bootstrap Switch
        /// </summary>
        public static string BootstrapSwitch { get { return GetPathFor(_keyBootstrapSwitch, _defaultBootstrapSwitch); } }
        /// <summary>
        /// Path to JQuery
        /// </summary>
        public static string JQuery { get { return GetPathFor(_keyJQuery, _defaultJQuery); } }
        /// <summary>
        /// Path to images
        /// </summary>
        public static string IMG { get { return GetPathFor(_keyIMG, _defaultIMG); } }
        /// <summary>
        /// Path to styles
        /// </summary>
        public static string CSS { get { return GetPathFor(_keyCSS, _defaultCSS); } }
        /// <summary>
        /// Path to scripts
        /// </summary>
        public static string JS { get { return GetPathFor(_keyJS, _defaultJS); } }
        #endregion

        #region Public Author's Info
        /// <summary>
        /// Author's fullname
        /// </summary>
        public static string AuthorName { get { return GetValueFor(_keyAuthorName, _defaultAuthorName); } }
        /// <summary>
        /// Author's email
        /// </summary>
        public static string AuthorEmail { get { return GetValueFor(_keyAuthorEmail, _defaultAuthorEmail); } }
        /// <summary>
        /// Author's profile url
        /// </summary>
        public static string AuthorProfileURL { get { return GetValueFor(_keyAuthorProfile, _defaultAuthorProfile); } }
        #endregion

        #region Public Matrix Settings
        /// <summary>
        /// Matrix's size
        /// </summary>
        public static int MatrixSize { get { return GetIntegerValueFor(_keyMatrixSize, _defaultMatrixSize); } }
        /// <summary>
        /// Matrix's base
        /// </summary>
        public static Enums.MatrixBase MatrixBase { get { return GetEnumValueFor<Enums.MatrixBase>(_keyMatrixBase, _defaultMatrixBase); } }
        /// <summary>
        /// Matrix's minimun size
        /// </summary>
        public static int MatrixMinSize { get { return GetIntegerValueFor(_keyMatrixMinSize, _defaultMatrixMinSize); } }
        /// <summary>
        /// Matrix's maximum size
        /// </summary>
        public static int MatrixMaxSize { get { return GetIntegerValueFor(_keyMatrixMaxSize, _defaultMatrixMaxSize); } }
        /// <summary>
        /// Show prime numbers flag
        /// </summary>
        public static bool ShowPrimeNumbers { get { return GetBooleanValueFor(_keyShowPrimeNumbers, _defaultMatrixShowPrimeNumbers); } }
        #endregion

        #region Help Methods
        /// <summary>
        /// Returns value from configuration file
        /// </summary>
        /// <param name="name">key</param>
        /// <param name="defaultValue">default value</param>
        /// <returns></returns>
        private static string GetValueFor(string name, string defaultValue)
        {
            var data = System.Configuration.ConfigurationManager.AppSettings[name];
            return string.IsNullOrWhiteSpace(data) ? defaultValue : data;
        }

        /// <summary>
        /// Returns integer value from configuration file
        /// </summary>
        /// <param name="name">key</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>Int32</returns>
        private static Int32 GetIntegerValueFor(string name, int defaultValue)
        {
            var result = defaultValue;
            var data = System.Configuration.ConfigurationManager.AppSettings[name];
            if (string.IsNullOrWhiteSpace(data))
                Int32.TryParse(data, out result);

            return result;
        }

        /// <summary>
        /// Returns Boolean value from configuration file
        /// </summary>
        /// <param name="name">key</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>Int32</returns>
        private static Boolean GetBooleanValueFor(string name, bool defaultValue)
        {
            var result = defaultValue;
            var data = System.Configuration.ConfigurationManager.AppSettings[name];
            if (string.IsNullOrWhiteSpace(data))
                Boolean.TryParse(data, out result);

            return result;
        }

        /// <summary>
        /// Returns Generic Enum value from configuration file
        /// </summary>
        /// <param name="name">key</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>Int32</returns>
        private static TEnum GetEnumValueFor<TEnum>(string name, TEnum defaultValue) where TEnum : struct, IComparable, IConvertible, IFormattable
        {
            var result = defaultValue;

            if (typeof(TEnum).IsEnum)
            {
                var data = System.Configuration.ConfigurationManager.AppSettings[name];
                if (string.IsNullOrWhiteSpace(data))
                    Enum.TryParse(data, true, out result);
            }

            return result;
        }

        /// <summary>
        /// Returns Content Path
        /// </summary>
        /// <param name="name">key</param>
        /// <param name="defaultValue">default value</param>
        /// <returns></returns>
        private static string GetPathFor(string name, string defaultValue)
        {
            var data = GetValueFor(name, defaultValue);
            return string.Format("{0}/{1}", _CDN, data);
        }
        #endregion
    }
}