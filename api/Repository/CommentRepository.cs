using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CommentRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<Comment> CreateAsync(Comment comment)
        {
            await _dbContext.Comments.AddAsync(comment);
            await _dbContext.SaveChangesAsync();

            return comment;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var commentModel = await _dbContext.Comments.FirstOrDefaultAsync(x => x.Id == id);

            if(commentModel == null)
            {
                return null;
            }

            _dbContext.Comments.Remove(commentModel);
            await _dbContext.SaveChangesAsync();

            return commentModel;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _dbContext.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _dbContext.Comments.FindAsync(id);
        }

        public async Task<Comment?> UpdateAsync(int id, Comment commentModel)
        {
            var existingComment = await _dbContext.Comments.FindAsync(id);

            if(existingComment == null)
            {
                return null;
            }

            existingComment.Title = commentModel.Title;
            existingComment.Content = commentModel.Content;

            await _dbContext.SaveChangesAsync();

            return existingComment;
        }
    }
}