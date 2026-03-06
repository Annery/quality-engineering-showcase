using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace Playwright.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    internal class TitleTests : PageTest
    {
        private const string ExpectedTitle = "Fast and reliable end-to-end testing for modern web apps | Playwright";
        private const string Url = "https://playwright.dev/";

        [TestCase("chromium")]
        [TestCase("firefox")]
        public async Task PlaywrightTitleIsExpected(string browserName)
        {
            await using var browser = await Playwright[browserName].LaunchAsync();
            var page = await browser.NewPageAsync();

            await page.GotoAsync(Url, new(){WaitUntil = WaitUntilState.DOMContentLoaded});

            await Expect(page).ToHaveTitleAsync(ExpectedTitle);
        }
    }
}