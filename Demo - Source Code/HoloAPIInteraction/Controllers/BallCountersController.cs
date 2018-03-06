using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HoloAPIInteraction.Models;

namespace HoloAPIInteraction.Controllers
{
    public class BallCountersController : ApiController
    {
        private HoloAPIInteractionContext db = new HoloAPIInteractionContext();

        // GET: api/BallCounters
        public IQueryable<BallCounter> GetBallCounters()
        {
            return db.BallCounters;
        }

        // GET: api/BallCounters/5
        [ResponseType(typeof(BallCounter))]
        public IHttpActionResult GetBallCounter(int id)
        {
            BallCounter ballCounter = db.BallCounters.Find(id);
            if (ballCounter == null)
            {
                return NotFound();
            }

            return Ok(ballCounter);
        }

        // PUT: api/BallCounters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBallCounter(int id, BallCounter ballCounter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ballCounter.Id)
            {
                return BadRequest();
            }

            db.Entry(ballCounter).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BallCounterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BallCounters
        [ResponseType(typeof(BallCounter))]
        public IHttpActionResult PostBallCounter(BallCounter ballCounter)
        {
          
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BallCounters.Add(ballCounter);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ballCounter.Id }, ballCounter);
        }

        // DELETE: api/BallCounters/5
        [ResponseType(typeof(BallCounter))]
        public IHttpActionResult DeleteBallCounter(int id)
        {
            BallCounter ballCounter = db.BallCounters.Find(id);
            if (ballCounter == null)
            {
                return NotFound();
            }

            db.BallCounters.Remove(ballCounter);
            db.SaveChanges();

            return Ok(ballCounter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BallCounterExists(int id)
        {
            return db.BallCounters.Count(e => e.Id == id) > 0;
        }
    }
}