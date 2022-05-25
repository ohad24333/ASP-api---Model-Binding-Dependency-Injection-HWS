using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ASP_api___Model_Binding___Dependency_Injection_HWS.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        private IDonationCount _donationCount;
        private ICriminalCount _criminalCount;
        public DonationController(IDonationCount donationCount,ICriminalCount criminalCount)
        {
            _donationCount = donationCount;
            _criminalCount = criminalCount;
        }

        [HttpPost("{name}/{family}")]
        public IActionResult Give([FromRoute] string name , string family,
                                  [FromQuery] int amount, int associationNum,
                                  [FromBody] DonationDateAndGenerous donationDateAndGenerous)
        {

            _donationCount.AddAmount(amount);
            int sum = _donationCount.GetSum();

            //From Criminal:
            _criminalCount.AddAmount(amount);
            int sumFromCriminal = _criminalCount.GetSum();

            return Ok(new
            {
                name,
                family,
                amount,
                associationNum,
                donationDateAndGenerous,
                sum,
                sumFromCriminal
            });
        }





    }
}
