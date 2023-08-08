using CodingTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;


namespace CodingTest.Controllers
{
    [ApiController]
    public class ListController : ControllerBase
    {
        private static List<ListObjects> lstObjects = new List<ListObjects>
            {
                new ListObjects
                {
                    Id=1,
                    Name="Lokesh"
                },
                new ListObjects
                {
                    Id=2,
                    Name="Kumar"
                }
            };
        
        /// <summary>
        /// This method inserts new object to the list
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [Route("/api/list")]
        [HttpPost]
        public IActionResult PostObjects([FromBody] ListObjects obj)
        {
            lstObjects.Add(obj);
            return Ok(lstObjects);
        }

        /// <summary>
        /// This method fetches specific object by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("/api/list/{id}")]
        [HttpGet]
        public IActionResult GetObjectsById(int id)
        {
            var obj = lstObjects.Find(x => x.Id == id);
            if (obj is null)
                return NotFound();

            return Ok(obj);
        }

        /// <summary>
        /// This method fetches all the objects
        /// </summary>
        /// <returns></returns>
        [Route("api/list")]
        [HttpGet]
        public IActionResult GetAllObjects()
        {
          return Ok(lstObjects);
        }


        [Route("/api/list/{id}")]
        [HttpPatch]
        public IActionResult PatchObjects([FromBody] int id)
        {
            var obj = lstObjects.Find(x => x.Id == id);
            return Ok(obj);
        }

        /// <summary>
        /// This method deletes the object by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("/api/list/{id}")]
        [HttpDelete]
        public IActionResult DeleteObject(int id)
        {
            var obj = lstObjects.Find(x => x.Id == id);
            if (obj is null)
                return NotFound();

            lstObjects.Remove(obj);
            return Ok(obj);
        }
    }
}
