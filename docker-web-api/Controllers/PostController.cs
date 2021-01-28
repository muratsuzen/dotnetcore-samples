using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace docker_web_api.Controllers
{
    [ApiController]
    [Route("post")]
    public class PostController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Post> Get(){
            using (var context = new BlogContext())
            {
                var postList = context.Posts.ToList();
                return postList;
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Post entity){
            using (var context = new BlogContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                return Ok(entity);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Post entity){
            using(var context = new BlogContext()){
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
                return Ok(entity);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int Id){
            using(var context = new BlogContext()){
                var findEntity = context.Posts.FirstOrDefault(x=>x.Id == Id);
                var deletedEntity = context.Entry(findEntity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
                return Ok();
            }
        }

    }
}