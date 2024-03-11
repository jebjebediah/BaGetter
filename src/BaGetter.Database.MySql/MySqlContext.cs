using BaGetter.Core;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace BaGetter.Database.MySql
{
    public class MySqlContext : AbstractContext<MySqlContext>
    {
        /// <summary>
        /// The MySQL Server error code for when a unique constraint is violated.
        /// </summary>
        private const int UniqueConstraintViolationErrorCode = 1062;

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
        }

        public override bool IsUniqueConstraintViolationException(DbUpdateException exception)
        {
            return exception.InnerException is MySqlException mysqlException &&
                   mysqlException.Number == UniqueConstraintViolationErrorCode;
        }

        /// <summary>
        /// MySQL does not support LIMIT clauses in subqueries for certain subquery operators.
        /// See: https://dev.mysql.com/doc/refman/8.0/en/subquery-restrictions.html
        /// </summary>
        public override bool SupportsLimitInSubqueries => false;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use the latin1 charset as default instead of the utf8mb4 to prevent the "Row size too large" error.
            modelBuilder.HasCharSet("latin1");

            base.OnModelCreating(modelBuilder);
        }
    }
}
