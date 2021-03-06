﻿using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Atata
{
    public class ChromeAtataContextBuilder : DriverAtataContextBuilder<ChromeAtataContextBuilder, ChromeDriverService, ChromeOptions>
    {
        public ChromeAtataContextBuilder(AtataBuildingContext buildingContext)
            : base(buildingContext, DriverAliases.Chrome)
        {
        }

        protected override ChromeDriverService CreateService()
            => ChromeDriverService.CreateDefaultService();

        protected override ChromeDriverService CreateService(string driverPath)
            => ChromeDriverService.CreateDefaultService(driverPath);

        protected override ChromeDriverService CreateService(string driverPath, string driverExecutableFileName)
            => ChromeDriverService.CreateDefaultService(driverPath, driverExecutableFileName);

        protected override RemoteWebDriver CreateDriver(ChromeDriverService service, ChromeOptions options, TimeSpan commandTimeout)
            => new ChromeDriver(service, options, commandTimeout);

        /// <summary>
        /// Adds arguments to be appended to the Chrome.exe command line.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        /// <returns>The same builder instance.</returns>
        public ChromeAtataContextBuilder WithArguments(params string[] arguments)
        {
            return WithOptions(options => options.AddArguments(arguments));
        }
    }
}
