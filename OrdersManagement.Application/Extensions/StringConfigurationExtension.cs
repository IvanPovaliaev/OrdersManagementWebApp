using System;
using System.Text.RegularExpressions;

namespace OrdersManagement.Application.Extensions
{
    /// <summary>
    /// Provides extension methods for string manipulation related to configuration settings.
    /// </summary>
    public static class StringConfigurationExtension
    {
        /// <summary>
        /// Replaces placeholders in the format of '${envVar}' with the corresponding environment variable value.
        /// If an environment variable is not found, the placeholder is left unchanged.
        /// </summary>
        /// <param name="input">The input string containing placeholders in the format '${envVar}'.</param>
        /// <returns>The input string with environment variable values substituted for the placeholders.</returns>
        public static string SetEnvironmentVariables(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return Regex.Replace(input, @"\$\{([^}]+)\}", match =>
            {
                var envVar = match.Groups[1].Value;
                return Environment.GetEnvironmentVariable(envVar) ?? match.Value;
            });
        }
    }
}
