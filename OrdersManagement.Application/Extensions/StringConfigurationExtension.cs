using System;
using System.Text.RegularExpressions;

namespace OrdersManagement.Application.Extensions
{
    public static class StringConfigurationExtension
    {
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
