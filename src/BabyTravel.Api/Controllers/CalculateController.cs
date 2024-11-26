using BabyTravel.Api.Models.Calculate.Diapers;
using BabyTravel.Api.Models.Calculate.Meals;
using BabyTravel.Api.Models.Calculate.Outfits;
using BabyTravel.Api.Models.Calculate.Sleep;
using BabyTravel.Api.Models.Shared;
using BabyTravel.Calculator;
using BabyTravel.Calculator.Models;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

namespace BabyTravel.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CalculateController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType<CalculateDiaperResponse>((int)HttpStatusCode.OK)]
        [ProducesResponseType<ErrorResponse>((int)HttpStatusCode.BadRequest)]
        public IActionResult Diapers(CalculateDiaperRequest request)
        {
            var diapers =
                Calculator.Diapers.For(Baby.WithBirthday(request.BabyBirthday))
                                  .Traveling(Travel.Between(request.TravelStartDate, request.TravelEndDate));

            return Ok(new CalculateDiaperResponse()
            {
                TotalDiapers = diapers.TotalDiapers,
                DiapersPerDay = diapers.DiapersPerDay
            });
        }

        [HttpPost]
        [ProducesResponseType<CalculateOutfitResponse>((int)HttpStatusCode.OK)]
        [ProducesResponseType<ErrorResponse>((int)HttpStatusCode.BadRequest)]
        public IActionResult Outfits(CalculateOutfitRequest request)
        {
            var outfits =
                Calculator.Outfits.For(Baby.WithBirthday(request.BabyBirthday))
                                  .WashEvery(request.WashingFrequencyInDays)
                                  .Traveling(Travel.Between(request.TravelStartDate, request.TravelEndDate));

            return Ok(new CalculateOutfitResponse()
            {
                TotalOutfits = outfits.TotalOutfits,
                TotalTops = outfits.TotalTops,
                TotalBottoms = outfits.TotalBottoms,
                TotalSocks = outfits.TotalSocks,
                TotalHats = outfits.TotalHats,
                TotalPajamas = outfits.TotalPajamas,
                TotalSleepsacks = outfits.TotalSleepsacks,
                OutfitsPerDay = outfits.OutfitsPerDay
            });
        }

        [HttpPost]
        [ProducesResponseType<CalculateMealResponse>((int)HttpStatusCode.OK)]
        [ProducesResponseType<ErrorResponse>((int)HttpStatusCode.BadRequest)]
        public IActionResult Meals(CalculateMealRequest request)
        {
            var meals =
                Calculator.Meals
                          .For(Baby.WithBirthday(request.BabyBirthday))
                          .Traveling(Travel.Between(request.TravelStartDate, request.TravelEndDate));

            return Ok(new CalculateMealResponse()
            {
                MealsPerDay = new IntRange(meals.MealsPerDay),
                SolidsPerDay = new IntRange(meals.SolidsPerDay),
                FeedingsPerDay = new IntRange(meals.FeedingsPerDay),
                SnacksPerDay = new IntRange(meals.SnacksPerDay),
                TotalSnacks = new IntRange(meals.TotalSnacks),
                TotalMeals = new IntRange(meals.TotalMeals),
                TotalFeedings = new IntRange(meals.TotalFeedings),
                TotalSolids = new IntRange(meals.TotalSolids)
            });
        }

        [HttpPost]
        [ProducesResponseType<CalculateSleepResponse>((int)HttpStatusCode.OK)]
        [ProducesResponseType<ErrorResponse>((int)HttpStatusCode.BadRequest)]
        public IActionResult Sleep(CalculateSleepRequest request)
        {
            var sleep =
                Calculator.Sleep.For(Baby.WithBirthday(request.BabyBirthday));

            return Ok(new CalculateSleepResponse()
            {
                NapLengthInHours = sleep.NapLengthInHours,
                NapsPerDay = new IntRange(sleep.NapsPerDay),
                SleepLengthInHours = sleep.SleepLengthInHours,
                WakeWindowInHours = sleep.WakeWindowInHours,
                TotalWakeHours = sleep.TotalWakeHours,
                TotalSleepInHours = sleep.TotalSleepHours
            });
        }
    }
}
