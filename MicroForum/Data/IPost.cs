﻿using MicroForum.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace MicroForum.Data
{
    public interface IPost
    {
        Post GetById(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetFiltered(string searchQuery);
        IEnumerable<Post> GetByForum(int id);
        Task Add(Post post);
        Task Delete(int id);
        Task EditContent(int id,string newContent);
       // Task AddReply(PostReply  reply);
    }
}