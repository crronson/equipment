using AutoMapper;
using EquipDisplay.Dtos;
using EquipDisplay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EquipDisplay.Controllers.Api
{
    public class DisplaysController : ApiController
    {

        private ApplicationDbContext _context;

        public DisplaysController()
        {
            _context = new ApplicationDbContext();
        }


        //GET /api/displays
        public IEnumerable<DisplayDto> GetDisplayItems()
        {

            return _context.Displays.ToList().Select(Mapper.Map<Display, DisplayDto>);

        }


        //GET /api/displays/1
        [HttpGet]
        [Route("Api/Displays/GetDisplays/{ExternalId}")]
        public DisplayDto GetDisplays(string ExternalId)
        {


            var disiplayInDb = _context.Displays.SingleOrDefault(d => d.ExternalId == ExternalId);

            if (disiplayInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Mapper.Map<Display, DisplayDto>(disiplayInDb);
        }

        //GET /api/displays/1
        [HttpGet]
        public DisplayDto GetDbDisplays(int ID)
        {
            
            var disiplayInDb = _context.Displays.SingleOrDefault(d => d.ID == ID);

            if (disiplayInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Mapper.Map<Display, DisplayDto>(disiplayInDb);
        }


        ////POST /api/displays
        //[HttpPost]
        //public DisplayDto CreateDisplayItem(DisplayDto displaydto)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.BadRequest);
        //    }

        //    var displayInDb = Mapper.Map<DisplayDto, Display>(displaydto);

        //    _context.Displays.Add(displayInDb);
            

        //    displaydto.ID = displayInDb.ID;

        //    _context.SaveChanges();

        //    return displaydto;

        //}


        ////PUT /api/displays/1
        //[HttpPut]
        //public void UpdateDiplayItem(string externalId, DisplayDto displayDto)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.BadRequest);
        //    }

        //    var displayInDb = _context.Displays.SingleOrDefault(d => d.ExternalId == externalId);

        //    if (displayInDb == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }


        //    Mapper.Map(displayDto, displayInDb);

        //    //displayInDb.MeterReading = displayDto.MeterReading;
        //    //displayInDb.Description = displayDto.Description;

        //    _context.SaveChanges();


        //}


        //// DELETE /api/displays/1
        //[HttpDelete]
        //public void DeleteDisplayItem(string externalId)
        //{

        //    var displayInDb = _context.Displays.SingleOrDefault(d => d.ExternalId == externalId);

        //    if (displayInDb == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }

        //    _context.Displays.Remove(displayInDb);
        //    _context.SaveChanges();

        //}


    }
}
