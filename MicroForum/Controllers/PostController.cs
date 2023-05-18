using MicroForum.Data;
using MicroForum.Models;
using MicroForum.Models.PostModels;
using MicroForum.Models.Reply;
using MicroForum.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MicroForum.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _postService;
        private readonly IForum _forumService;
        private readonly ApplicationDbContext _context;

        private static UserManager<ApplicationUser> _userManager;
        public PostController(IPost postService, IForum forumService,ApplicationDbContext context,UserManager<ApplicationUser> userManager)
            {
                _context = context;
            _userManager = userManager;
            _postService = postService;
            _forumService = forumService;
        }

        public IActionResult Index(int id)
        {
            var post = _postService.GetById(id);
            var replies = BuildPostReplies(post.Replies);
            var model = new PostIndexModel
                {
                Id = post.Id,
                Title = post.Title,
                AuthorId = post.User.Id,
                AuthorName = post.User.UserName,
                AuthorImageUrl = post.User.ProfileImageUrl,
                CreatedDate = post.CreatedDate,
                PostContent = post.Content,
                Replies = replies,
                IsAdmin = isAdmin(post.User)
            };
            return View(model);
        }

       

        public IActionResult Create(int id)
        {
            var forum = _forumService.GetById(id);
            var model = new NewPostModel
            {
                ForumName = forum.Name,
                ForumId = forum.Id,
                ForumImageUrl = forum.ImageUrl,
                AuthorName = User.Identity.Name
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(NewPostModel model)
        {
             var userId = _userManager.GetUserId(User);
           ///// var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

             var user = await _userManager.FindByIdAsync(userId);
           ////// var user = _context.Users.FirstOrDefault(u => u.Id == userId);

            var post = BuildPost(model,user);

            await _postService.Add(post);

            //implement use rrating

            return RedirectToAction("Index", "Post", new {id = post.Id});


        }

        private Post BuildPost(NewPostModel model, ApplicationUser user)
        {
            var forum = _forumService.GetById(model.ForumId);
            return new Post
            {
                Title = model.Title,
                Content = model.Content,
                CreatedDate = DateTime.Now,
                User = user,
                Forum = forum
            };

        }

        private IEnumerable<PostReplyModel> BuildPostReplies(IEnumerable<PostReply>? postReplies)
        {
            return postReplies.Select(reply => new PostReplyModel
            {
                Id = reply.Id,
                AuthorName = reply.User.UserName,
                AuthorImageUrl = reply.User.ProfileImageUrl,
                CreatedDate = reply.CreatedDate,
                AuthorRating = reply.User.Rating,
                AuthorId = reply.User.Id,
                ReplyContent = reply.Content,
                IsAdmin = isAdmin(reply.User)
            });
        }
         private bool isAdmin(ApplicationUser user)
        {
            return _userManager.GetRolesAsync(user)
                .Result.Contains("Admin");
        }
    }
}
