using System;
using TechTalk.SpecFlow;

namespace csharpRestClient.Features
{
    [Binding]
    public class RestAPISteps
    {
        [Given(@"I'm requesting latest currency list")]
        public void GivenIMRequestingLatestCurrencyList()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I make a request")]
        public void WhenIMakeARequest()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The response should include list of currencies")]
        public void ThenTheResponseShouldIncludeListOfCurrencies()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
