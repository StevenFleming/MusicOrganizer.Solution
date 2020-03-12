using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;

namespace MusicOrganizer.Controllers
{
    public class ArtistsController : Controller
    {
        [HttpGet("/artists")]
        public ActionResult Index()
        {
            List<Artist> allArtists = Artist.GetAll();
            return View(allArtists);
        }

        [HttpGet("/artists/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/artists")]
        public ActionResult Create(string artistName)
        {
            Artist newArtist = new Artist(artistName);
            return RedirectToAction("Index");
        }

        [HttpGet("/artists/{id}")]
        public ActionResult Show(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Artist selectedArtist = Artist.FindById(id);
            List<Record> artistRecords = selectedArtist.Records;
            model.Add("artist", selectedArtist);
            model.Add("records", artistRecords);
            return View(model);
        }
    }
}