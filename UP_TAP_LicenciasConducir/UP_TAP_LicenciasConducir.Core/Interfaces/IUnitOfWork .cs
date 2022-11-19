using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UP_TAP_LicenciasConducir.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //IPostRepository PostRepository { get; }

        //IRepository<User> UserRepository { get; }

        //IRepository<Comment> CommentRepository { get; }

        //ISecurityRepository SecurityRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
