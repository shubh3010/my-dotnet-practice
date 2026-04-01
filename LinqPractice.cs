// using Microsoft.EntityFrameworkCore;
// using Models;
// using Repository;

// namespace BlogPractice;

// /// <summary>
// /// LINQ & C# Practice Questions — BlogPractice Codebase
// /// =====================================================
// /// 
// /// Entity Relationships:
// ///   Author  1──*  Post  *──*  Tag
// ///                  │
// ///                  1──*  Comment
// ///   User (standalone, base entity with virtual GetDisplayName())
// ///
// /// Instructions:
// ///   1. Each method has a description of WHAT to return.
// ///   2. Write your LINQ query inside the method body (replace the `throw`).
// ///   3. Run the tests or call from a controller to verify.
// ///   4. Solutions are at the bottom of this file — NO PEEKING until you try!
// ///
// /// Difficulty scale:  ★ Easy  ★★ Medium  ★★★ Hard  ★★★★ Expert
// /// </summary>
// public class LinqPractice
// {
//     private readonly BloggingContext _ctx;

//     public LinqPractice(BloggingContext ctx) => _ctx = ctx;


//     // ═══════════════════════════════════════════════════════════════
//     //  SECTION 1 — FILTERING & PROJECTION
//     // ═══════════════════════════════════════════════════════════════

//     /// <summary>
//     /// ★ Q1: Return all post titles published after a given date, ordered newest first.
//     /// </summary>
//     public async Task<List<string>> Q01_PostTitlesAfterDate(DateTime date, CancellationToken ct = default)
//     {
//         throw new NotImplementedException();
//     }

//     /// <summary>
//     /// ★ Q2: Return all distinct tag names used across all posts, sorted alphabetically.
//     /// </summary>
//     public async Task<List<string>> Q02_AllDistinctTagNames(CancellationToken ct = default)
//     {
//         throw new NotImplementedException();
//     }

//     /// <summary>
//     /// ★★ Q3: Return posts where the title contains a search term (case-insensitive)
//     ///         AND the post has at least one comment.
//     ///         Project to: new { PostId, Title, CommentCount }
//     /// </summary>
//     public async Task<List<object>> Q03_SearchPostsWithComments(string searchTerm, CancellationToken ct = default)
//     {
//         throw new NotImplementedException();
//     }


//     // ═══════════════════════════════════════════════════════════════
//     //  SECTION 2 — GROUPING & AGGREGATION
//     // ═══════════════════════════════════════════════════════════════

//     /// <summary>
//     /// ★★ Q4: Return the number of posts per author.
//     ///         Project to: new { AuthorName, PostCount }
//     ///         Order by PostCount descending.
//     /// </summary>
//     public async Task<List<object>> Q04_PostCountPerAuthor(CancellationToken ct = default)
//     {
//         throw new NotImplementedException();
//     }

//     /// <summary>
//     /// ★★ Q5: Return the average number of comments per post, grouped by author.
//     ///         Project to: new { AuthorName, AvgComments }
//     ///         Hint: Use nested grouping or SelectMany.
//     /// </summary>
//     public async Task<List<object>> Q05_AvgCommentsPerPostByAuthor(CancellationToken ct = default)
//     {
//         throw new NotImplementedException();
//     }

//     /// <summary>
//     /// ★★★ Q6: Group posts by the MONTH+YEAR they were published.
//     ///          Return: new { Month (string "yyyy-MM"), PostCount }
//     ///          Ordered chronologically.
//     /// </summary>
//     public async Task<List<object>> Q06_PostsPerMonth(CancellationToken ct = default)
//     {
//         throw new NotImplementedException();
//     }

//     /// <summary>
//     /// ★★★ Q7: Find the tag that is used on the most posts.
//     ///          Return: new { TagName, PostCount }
//     ///          If there's a tie, return all tied tags.
//     /// </summary>
//     public async Task<List<object>> Q07_MostPopularTags(CancellationToken ct = default)
//     {
//         throw new NotImplementedException();
//     }


//     // ═══════════════════════════════════════════════════════════════
//     //  SECTION 3 — JOINS (method syntax)
//     // ═══════════════════════════════════════════════════════════════

//     /// <summary>
//     /// ★★ Q8: Using an explicit Join (not navigation properties), return:
//     ///         new { PostTitle, AuthorEmail }
//     ///         for all posts.
//     /// </summary>
//     public async Task<List<object>> Q08_InnerJoinPostAuthor(CancellationToken ct = default)
//     {
//         throw new NotImplementedException();
//     }

//     /// <summary>
//     /// ★★★ Q9: LEFT JOIN — Return all authors and their post titles.
//     ///          Authors with no posts should appear with Title = "No Posts".
//     ///          Use GroupJoin + SelectMany + DefaultIfEmpty pattern.
//     ///          Return: new { AuthorName, PostTitle }
//     /// </summary>
//     public async Task<List<object>> Q09_LeftJoinAuthorsWithPosts(CancellationToken ct = default)
//     {
//         throw new NotImplementedException();
//     }

//     /// <summary>
//     /// ★★★ Q10: CROSS JOIN — Return every combination of Author × Tag.
//     ///           Return: new { AuthorName, TagName }
//     ///           Hint: Use SelectMany without a correlation.
//     /// </summary>
//     public async Task<List<object>> Q10_CrossJoinAuthorTag(CancellationToken ct = default)
//     {
//         throw new NotImplementedException();
//     }


//     // ═══════════════════════════════════════════════════════════════
//     //  SECTION 4 — SUBQUERIES & EXISTENCE CHECKS
//     // ═══════════════════════════════════════════════════════════════

//     /// <summary>
//     /// ★★ Q11: Return authors who have published at least one post tagged "csharp".
//     ///          Return: List of author UserNames.
//     /// </summary>
//     public async Task<List<string>> Q11_AuthorsWithCSharpTag(CancellationToken ct = default)
//     {
//         throw new NotImplementedException();
//     }

//     /// <summary>
//     /// ★★★ Q12: Return posts that have NO comments (anti-join).
//     ///           Return: new { PostId, Title }
//     /// </summary>
//     public async Task<List<object>> Q12_PostsWithNoComments(CancellationToken ct = default)
//     {
//         throw new NotImplementedException();
//     }

//     /// <summary>
//     /// ★★★ Q13: Return posts where EVERY comment was written by "Anonymous".
//     ///           (Posts with 0 comments should NOT be included.)
//     ///           Return: new { PostId, Title }
//     ///           Hint: All() + Any() combination.
//     /// </summary>
//     public async Task<List<object>> Q13_PostsAllAnonymousComments(CancellationToken ct = default)
//     {
//         throw new NotImplementedException();
//     }


//     // ═══════════════════════════════════════════════════════════════
//     //  SECTION 5 — PAGINATION, SORTING & DYNAMIC QUERIES
//     // ═══════════════════════════════════════════════════════════════

//     /// <summary>
//     /// ★★ Q14: Implement keyset pagination (seek method) for posts.
//     ///          Given the lastPublishedAt and lastId of the previous page,
//     ///          return the next `pageSize` posts ordered by PublishedAt DESC, then Id DESC.
//     ///          This is more efficient than Skip/Take for large datasets.
//     /// </summary>
//     public async Task<List<Post>> Q14_KeysetPagination(DateTime? lastPublishedAt, int? lastId, int pageSize, CancellationToken ct = default)
//     {
//         throw new NotImplementedException();
//     }

//     /// <summary>
//     /// ★★★ Q15: Build a dynamic query using IQueryable.
//     ///           Accept optional filters: authorId, tag, fromDate, toDate, searchTerm.
//     ///           Only apply each filter if the parameter is non-null/non-empty.
//     ///           Return matching posts with their Author and Tags loaded.
//     /// </summary>
//     public async Task<List<Post>> Q15_DynamicFilter(
//         int? authorId, string? tag, DateTime? fromDate, DateTime? toDate, string? searchTerm,
//         int page = 1, int pageSize = 10, CancellationToken ct = default)
//     {
//         throw new NotImplementedException();
//     }


//     // ═══════════════════════════════════════════════════════════════
//     //  SECTION 6 — ADVANCED PROJECTIONS & DTOs
//     // ═══════════════════════════════════════════════════════════════

//     /// <summary>
//     /// ★★★ Q16: Return a "dashboard" DTO for each author:
//     ///           new {
//     ///               AuthorName,
//     ///               TotalPosts,
//     ///               TotalComments,           // across all their posts
//     ///               MostRecentPostTitle,      // null if no posts
//     ///               MostRecentPostDate,       // null if no posts
//     ///               TopTags                   // List<string> — top 3 tags by usage count across their posts
//     ///           }
//     /// </summary>
//     public async Task<List<object>> Q16_AuthorDashboard(CancellationToken ct = default)
//     {
//         throw new NotImplementedException();
//     }

//     /// <summary>
//     /// ★★★ Q17: Flatten the many-to-many Post-Tag relationship.
//     ///           Return: new { PostTitle, TagName }
//     ///           One row per post-tag combination.
//     ///           Hint: SelectMany on a navigation property.
//     /// </summary>
//     public async Task<List<object>> Q17_FlattenPostTags(CancellationToken ct = default)
//     {
//         throw new NotImplementedException();
//     }


//     // ═══════════════════════════════════════════════════════════════
//     //  SECTION 7 — SET OPERATIONS & COMPARISONS
//     // ═══════════════════════════════════════════════════════════════

//     /// <summary>
//     /// ★★★ Q18: Find tags that exist but are NOT assigned to any post.
//     ///           Return: List of tag Names.
//     ///           Hint: Use Except or Where + !Any.
//     /// </summary>
//     public async Task<List<string>> Q18_OrphanedTags(CancellationToken ct = default)
//     {
//         throw new NotImplementedException();
//     }

//     /// <summary>
//     /// ★★★ Q19: Find authors who have used ALL existing tags across their posts.
//     ///           (i.e., the set of tags on their posts is a superset of all tags.)
//     ///           Return: List of author UserNames.
//     /// </summary>
//     public async Task<List<string>> Q19_AuthorsUsingAllTags(CancellationToken ct = default)
//     {
//         throw new NotImplementedException();
//     }


//     // ═══════════════════════════════════════════════════════════════
//     //  SECTION 8 — WINDOW-STYLE & RANKING QUERIES
//     // ═══════════════════════════════════════════════════════════════

//     /// <summary>
//     /// ★★★★ Q20: For each author, return their most recent post (Rank 1 per partition).
//     ///            If an author has no posts, exclude them.
//     ///            Return: new { AuthorName, PostTitle, PublishedAt }
//     ///            Hint: GroupBy + Select with ordering inside each group.
//     /// </summary>
//     public async Task<List<object>> Q20_MostRecentPostPerAuthor(CancellationToken ct = default)
//     {
//         throw new NotImplementedException();
//     }

//     /// <summary>
//     /// ★★★★ Q21: Rank authors by their total comment count (across all posts).
//     ///            Return: new { Rank, AuthorName, TotalComments }
//     ///            Rank = 1 for the author with the most comments.
//     ///            Handle ties by giving the same rank (dense rank).
//     /// </summary>
//     public async Task<List<object>> Q21_AuthorCommentRanking(CancellationToken ct = default)
//     {
//         throw new NotImplementedException();
//     }


//     // ═══════════════════════════════════════════════════════════════
//     //  SECTION 9 — RAW SQL & HYBRID QUERIES
//     // ═══════════════════════════════════════════════════════════════

//     /// <summary>
//     /// ★★★ Q22: Use FromSqlInterpolated to find posts whose Content
//     ///           contains a search term, then further filter with LINQ
//     ///           to only include posts with > 2 comments.
//     ///           Return the Post entities.
//     /// </summary>
//     public async Task<List<Post>> Q22_HybridRawSqlAndLinq(string searchTerm, CancellationToken ct = default)
//     {
//         throw new NotImplementedException();
//     }


//     // ═══════════════════════════════════════════════════════════════
//     //  SECTION 10 — PURE C# LINQ (in-memory collections)
//     // ═══════════════════════════════════════════════════════════════

//     /// <summary>
//     /// ★★ Q23: Given a list of posts (in-memory), group them by AuthorId
//     ///          and return a Dictionary<int, List<string>> where
//     ///          key = AuthorId, value = list of post Titles sorted A-Z.
//     /// </summary>
//     public Dictionary<int, List<string>> Q23_GroupPostsByAuthor(List<Post> posts)
//     {
//         throw new NotImplementedException();
//     }

//     /// <summary>
//     /// ★★★ Q24: Given two lists — allTags and postTags —
//     ///           return the tags in allTags that are NOT in postTags,
//     ///           compared by Tag.Name (case-insensitive).
//     ///           Hint: Use ExceptBy, or Except with a custom IEqualityComparer, or Where+!Contains.
//     /// </summary>
//     public List<Tag> Q24_TagsNotOnPost(List<Tag> allTags, List<Tag> postTags)
//     {
//         throw new NotImplementedException();
//     }

//     /// <summary>
//     /// ★★★★ Q25: Given a flat list of comments, produce a nested structure:
//     ///            Dictionary<int, Dictionary<string, int>>
//     ///            Outer key = PostId
//     ///            Inner key = AuthorName
//     ///            Inner value = how many comments that author left on that post.
//     /// </summary>
//     public Dictionary<int, Dictionary<string, int>> Q25_CommentHeatMap(List<Comment> comments)
//     {
//         throw new NotImplementedException();
//     }
// }


// // ╔══════════════════════════════════════════════════════════════════╗
// // ║                                                                  ║
// // ║                      S O L U T I O N S                           ║
// // ║                                                                  ║
// // ║  STOP! Try each question on your own first.                      ║
// // ║  Scroll down only when you're stuck or want to verify.           ║
// // ║                                                                  ║
// // ╚══════════════════════════════════════════════════════════════════╝



// class User
// {
// class Customer { public int Id; public string Name; }
// class Invoice { public int Id; public int? CustomerId; public decimal Amount; }


//     public static void RunLinqExamples()
//     {
//         var customers = new List<Customer>{ new(){Id=1,Name="A"}, new(){Id=2,Name="B"} };
//         var invoices = new List<Invoice>{ new(){Id=1,CustomerId=1,Amount=100}, new(){Id=2,CustomerId=null,Amount=20} };


//         // Task: return all customers + their total invoice amounts.
//         //       Customers with no invoices → 0.
//         //       Invoices with null CustomerId → "Unknown".
//         // Expected: [("A", 100), ("B", 0), ("Unknown", 20)]

//         // Step 1: LEFT JOIN customers → invoices that have a known CustomerId
//         //         GroupJoin gives every customer a (possibly empty) bucket of invoices.
//         //         Filter orphans out first; cast outer key to int? so types align.
//         var customerTotals = customers.GroupJoin(
//             invoices.Where(i => i.CustomerId != null),  // exclude orphans
//             c => (int?)c.Id,                             // outer key (int → int?)
//             i => i.CustomerId,                           // inner key (int?)
//             (c, invs) => new { CustomerName = c.Name, Total = invs.Sum(i => i.Amount) }
//             // GroupJoin keeps all customers; invs is empty for "B" → Sum = 0
//         );

//         // Step 2: collect orphaned invoices (CustomerId == null) as "Unknown"
//         var unknownGroup = invoices
//             .Where(i => i.CustomerId == null)
//             .GroupBy(_ => "Unknown")                     // single group keyed "Unknown"
//             .Select(g => new { CustomerName = g.Key, Total = g.Sum(i => i.Amount) });
//             // same anonymous type shape as customerTotals → Concat compiles

//         // Step 3: merge both halves
//         var result = customerTotals.Concat(unknownGroup).ToList();
//         // result => [{ A, 100 }, { B, 0 }, { Unknown, 20 }]
//     }

// }

















// // ═══════════════════════════════════════════════════════════════════
// //                        SOLUTIONS
// // ═══════════════════════════════════════════════════════════════════

// public class LinqPracticeSolutions
// {
//     private readonly BloggingContext _ctx;
//     public LinqPracticeSolutions(BloggingContext ctx) => _ctx = ctx;


//     // ── Q1 ──────────────────────────────────────────────────────
//     public async Task<List<string>> Q01_PostTitlesAfterDate(DateTime date, CancellationToken ct = default)
//     {
//         return await _ctx.Posts
//             .Where(p => p.PublishedAt > date)
//             .OrderByDescending(p => p.PublishedAt)
//             .Select(p => p.Title)
//             .AsNoTracking()
//             .ToListAsync(ct);
//     }

//     // ── Q2 ──────────────────────────────────────────────────────
//     public async Task<List<string>> Q02_AllDistinctTagNames(CancellationToken ct = default)
//     {
//         return await _ctx.Tags
//             .Select(t => t.Name)
//             .Distinct()
//             .OrderBy(n => n)
//             .ToListAsync(ct);
//     }

//     // ── Q3 ──────────────────────────────────────────────────────
//     public async Task<List<object>> Q03_SearchPostsWithComments(string searchTerm, CancellationToken ct = default)
//     {
//         return await _ctx.Posts
//             .Where(p => EF.Functions.Like(p.Title, $"%{searchTerm}%"))
//             .Where(p => p.Comments.Any())
//             .Select(p => (object)new { PostId = p.Id, p.Title, CommentCount = p.Comments.Count })
//             .AsNoTracking()
//             .ToListAsync(ct);
//     }

//     // ── Q4 ──────────────────────────────────────────────────────
//     public async Task<List<object>> Q04_PostCountPerAuthor(CancellationToken ct = default)
//     {
//         return await _ctx.Authors
//             .Select(a => (object)new
//             {
//                 AuthorName = a.UserName,
//                 PostCount = a.Posts.Count
//             })
//             .OrderByDescending(x => ((dynamic)x).PostCount)
//             .AsNoTracking()
//             .ToListAsync(ct);

//         // Alternative with GroupBy:
//         // return await _ctx.Posts
//         //     .GroupBy(p => p.Author.UserName)
//         //     .Select(g => (object)new { AuthorName = g.Key, PostCount = g.Count() })
//         //     .OrderByDescending(x => ((dynamic)x).PostCount)
//         //     .ToListAsync(ct);
//     }

//     // ── Q5 ──────────────────────────────────────────────────────
//     public async Task<List<object>> Q05_AvgCommentsPerPostByAuthor(CancellationToken ct = default)
//     {
//         return await _ctx.Authors
//             .Where(a => a.Posts.Any())
//             .Select(a => (object)new
//             {
//                 AuthorName = a.UserName,
//                 AvgComments = a.Posts.Average(p => (double)p.Comments.Count)
//             })
//             .AsNoTracking()
//             .ToListAsync(ct);
//     }

//     // ── Q6 ──────────────────────────────────────────────────────
//     public async Task<List<object>> Q06_PostsPerMonth(CancellationToken ct = default)
//     {
//         return await _ctx.Posts
//             .GroupBy(p => new { p.PublishedAt.Year, p.PublishedAt.Month })
//             .OrderBy(g => g.Key.Year).ThenBy(g => g.Key.Month)
//             .Select(g => (object)new
//             {
//                 Month = $"{g.Key.Year:D4}-{g.Key.Month:D2}",
//                 PostCount = g.Count()
//             })
//             .ToListAsync(ct);
//     }

//     // ── Q7 ──────────────────────────────────────────────────────
//     public async Task<List<object>> Q07_MostPopularTags(CancellationToken ct = default)
//     {
//         var tagCounts = await _ctx.Tags
//             .Select(t => new { t.Name, PostCount = t.Posts.Count })
//             .ToListAsync(ct);

//         var maxCount = tagCounts.Max(t => t.PostCount);

//         return tagCounts
//             .Where(t => t.PostCount == maxCount)
//             .Select(t => (object)new { TagName = t.Name, t.PostCount })
//             .ToList();
//     }

//     // ── Q8 ──────────────────────────────────────────────────────
//     public async Task<List<object>> Q08_InnerJoinPostAuthor(CancellationToken ct = default)
//     {
//         return await _ctx.Posts
//             .Join(
//                 _ctx.Authors,
//                 post => post.AuthorId,
//                 author => author.Id,
//                 (post, author) => (object)new { PostTitle = post.Title, AuthorEmail = author.Email }
//             )
//             .AsNoTracking()
//             .ToListAsync(ct);
//     }

//     // ── Q9 ──────────────────────────────────────────────────────
//     public async Task<List<object>> Q09_LeftJoinAuthorsWithPosts(CancellationToken ct = default)
//     {
//         return await _ctx.Authors
//             .GroupJoin(
//                 _ctx.Posts,
//                 author => author.Id,
//                 post => post.AuthorId,
//                 (author, posts) => new { author, posts }
//             )
//             .SelectMany(
//                 x => x.posts.DefaultIfEmpty(),
//                 (x, post) => (object)new
//                 {
//                     AuthorName = x.author.UserName,
//                     PostTitle = post != null ? post.Title : "No Posts"
//                 }
//             )
//             .AsNoTracking()
//             .ToListAsync(ct);
//     }

//     // ── Q10 ─────────────────────────────────────────────────────
//     public async Task<List<object>> Q10_CrossJoinAuthorTag(CancellationToken ct = default)
//     {
//         return await _ctx.Authors
//             .SelectMany(
//                 _ => _ctx.Tags,
//                 (author, tag) => (object)new { AuthorName = author.UserName, TagName = tag.Name }
//             )
//             .AsNoTracking()
//             .ToListAsync(ct);
//     }

//     // ── Q11 ─────────────────────────────────────────────────────
//     public async Task<List<string>> Q11_AuthorsWithCSharpTag(CancellationToken ct = default)
//     {
//         return await _ctx.Authors
//             .Where(a => a.Posts.Any(p => p.Tags.Any(t => t.Name == "csharp")))
//             .Select(a => a.UserName)
//             .AsNoTracking()
//             .ToListAsync(ct);
//     }

//     // ── Q12 ─────────────────────────────────────────────────────
//     public async Task<List<object>> Q12_PostsWithNoComments(CancellationToken ct = default)
//     {
//         return await _ctx.Posts
//             .Where(p => !p.Comments.Any())
//             .Select(p => (object)new { PostId = p.Id, p.Title })
//             .AsNoTracking()
//             .ToListAsync(ct);
//     }

//     // ── Q13 ─────────────────────────────────────────────────────
//     public async Task<List<object>> Q13_PostsAllAnonymousComments(CancellationToken ct = default)
//     {
//         return await _ctx.Posts
//             .Where(p => p.Comments.Any())   // must have at least one comment
//             .Where(p => p.Comments.All(c => c.AuthorName == "Anonymous"))
//             .Select(p => (object)new { PostId = p.Id, p.Title })
//             .AsNoTracking()
//             .ToListAsync(ct);
//     }

//     // ── Q14 ─────────────────────────────────────────────────────
//     public async Task<List<Post>> Q14_KeysetPagination(DateTime? lastPublishedAt, int? lastId, int pageSize, CancellationToken ct = default)
//     {
//         var query = _ctx.Posts.AsNoTracking();

//         if (lastPublishedAt.HasValue && lastId.HasValue)
//         {
//             query = query.Where(p =>
//                 p.PublishedAt < lastPublishedAt.Value ||
//                 (p.PublishedAt == lastPublishedAt.Value && p.Id < lastId.Value));
//         }

//         return await query
//             .OrderByDescending(p => p.PublishedAt)
//             .ThenByDescending(p => p.Id)
//             .Take(pageSize)
//             .ToListAsync(ct);
//     }

//     // ── Q15 ─────────────────────────────────────────────────────
//     public async Task<List<Post>> Q15_DynamicFilter(
//         int? authorId, string? tag, DateTime? fromDate, DateTime? toDate, string? searchTerm,
//         int page = 1, int pageSize = 10, CancellationToken ct = default)
//     {
//         IQueryable<Post> query = _ctx.Posts
//             .Include(p => p.Author)
//             .Include(p => p.Tags);

//         if (authorId.HasValue)
//             query = query.Where(p => p.AuthorId == authorId.Value);

//         if (!string.IsNullOrWhiteSpace(tag))
//             query = query.Where(p => p.Tags.Any(t => t.Name == tag));

//         if (fromDate.HasValue)
//             query = query.Where(p => p.PublishedAt >= fromDate.Value);

//         if (toDate.HasValue)
//             query = query.Where(p => p.PublishedAt <= toDate.Value);

//         if (!string.IsNullOrWhiteSpace(searchTerm))
//             query = query.Where(p => EF.Functions.Like(p.Title, $"%{searchTerm}%")
//                                   || EF.Functions.Like(p.Content, $"%{searchTerm}%"));

//         return await query
//             .OrderByDescending(p => p.PublishedAt)
//             .Skip((page - 1) * pageSize)
//             .Take(pageSize)
//             .AsNoTracking()
//             .ToListAsync(ct);
//     }

//     // ── Q16 ─────────────────────────────────────────────────────
//     public async Task<List<object>> Q16_AuthorDashboard(CancellationToken ct = default)
//     {
//         return await _ctx.Authors
//             .Select(a => (object)new
//             {
//                 AuthorName = a.UserName,
//                 TotalPosts = a.Posts.Count,
//                 TotalComments = a.Posts.SelectMany(p => p.Comments).Count(),
//                 MostRecentPostTitle = a.Posts
//                     .OrderByDescending(p => p.PublishedAt)
//                     .Select(p => p.Title)
//                     .FirstOrDefault(),
//                 MostRecentPostDate = (DateTime?)a.Posts
//                     .OrderByDescending(p => p.PublishedAt)
//                     .Select(p => p.PublishedAt)
//                     .FirstOrDefault(),
//                 TopTags = a.Posts
//                     .SelectMany(p => p.Tags)
//                     .GroupBy(t => t.Name)
//                     .OrderByDescending(g => g.Count())
//                     .Select(g => g.Key)
//                     .Take(3)
//                     .ToList()
//             })
//             .AsNoTracking()
//             .ToListAsync(ct);
//     }

//     // ── Q17 ─────────────────────────────────────────────────────
//     public async Task<List<object>> Q17_FlattenPostTags(CancellationToken ct = default)
//     {
//         return await _ctx.Posts
//             .SelectMany(
//                 p => p.Tags,
//                 (post, tag) => (object)new { PostTitle = post.Title, TagName = tag.Name }
//             )
//             .AsNoTracking()
//             .ToListAsync(ct);
//     }

//     // ── Q18 ─────────────────────────────────────────────────────
//     public async Task<List<string>> Q18_OrphanedTags(CancellationToken ct = default)
//     {
//         return await _ctx.Tags
//             .Where(t => !t.Posts.Any())
//             .Select(t => t.Name)
//             .ToListAsync(ct);
//     }

//     // ── Q19 ─────────────────────────────────────────────────────
//     public async Task<List<string>> Q19_AuthorsUsingAllTags(CancellationToken ct = default)
//     {
//         var totalTagCount = await _ctx.Tags.CountAsync(ct);

//         return await _ctx.Authors
//             .Where(a => a.Posts
//                 .SelectMany(p => p.Tags)
//                 .Select(t => t.Id)
//                 .Distinct()
//                 .Count() == totalTagCount)
//             .Select(a => a.UserName)
//             .ToListAsync(ct);
//     }

//     // ── Q20 ─────────────────────────────────────────────────────
//     public async Task<List<object>> Q20_MostRecentPostPerAuthor(CancellationToken ct = default)
//     {
//         return await _ctx.Authors
//             .Where(a => a.Posts.Any())
//             .Select(a => new
//             {
//                 MostRecent = a.Posts.OrderByDescending(p => p.PublishedAt).First()
//             })
//             .Select(x => (object)new
//             {
//                 AuthorName = x.MostRecent.Author.UserName,
//                 PostTitle = x.MostRecent.Title,
//                 x.MostRecent.PublishedAt
//             })
//             .AsNoTracking()
//             .ToListAsync(ct);

//         // Alternative approach using GroupBy on Posts:
//         // return await _ctx.Posts
//         //     .GroupBy(p => p.AuthorId)
//         //     .Select(g => g.OrderByDescending(p => p.PublishedAt).First())
//         //     .Select(p => (object)new { AuthorName = p.Author.UserName, PostTitle = p.Title, p.PublishedAt })
//         //     .ToListAsync(ct);
//     }

//     // ── Q21 ─────────────────────────────────────────────────────
//     public async Task<List<object>> Q21_AuthorCommentRanking(CancellationToken ct = default)
//     {
//         var data = await _ctx.Authors
//             .Select(a => new
//             {
//                 AuthorName = a.UserName,
//                 TotalComments = a.Posts.SelectMany(p => p.Comments).Count()
//             })
//             .OrderByDescending(x => x.TotalComments)
//             .ToListAsync(ct);

//         // Dense rank in memory
//         var ranked = new List<object>();
//         int rank = 0;
//         int? prevCount = null;

//         foreach (var item in data)
//         {
//             if (item.TotalComments != prevCount)
//                 rank++;
//             prevCount = item.TotalComments;
//             ranked.Add(new { Rank = rank, item.AuthorName, item.TotalComments });
//         }

//         return ranked;
//     }

//     // ── Q22 ─────────────────────────────────────────────────────
//     public async Task<List<Post>> Q22_HybridRawSqlAndLinq(string searchTerm, CancellationToken ct = default)
//     {
//         return await _ctx.Posts
//             .FromSqlInterpolated($"SELECT * FROM Posts WHERE Content LIKE {'%' + searchTerm + '%'}")
//             .Include(p => p.Comments)
//             .Where(p => p.Comments.Count > 2)
//             .AsNoTracking()
//             .ToListAsync(ct);
//     }

//     // ── Q23 (in-memory) ─────────────────────────────────────────
//     public Dictionary<int, List<string>> Q23_GroupPostsByAuthor(List<Post> posts)
//     {
//         return posts
//             .GroupBy(p => p.AuthorId)
//             .ToDictionary(
//                 g => g.Key,
//                 g => g.Select(p => p.Title).OrderBy(t => t).ToList()
//             );
//     }

//     // ── Q24 (in-memory) ─────────────────────────────────────────
//     public List<Tag> Q24_TagsNotOnPost(List<Tag> allTags, List<Tag> postTags)
//     {
//         var postTagNames = postTags
//             .Select(t => t.Name.ToLowerInvariant())
//             .ToHashSet();

//         return allTags
//             .Where(t => !postTagNames.Contains(t.Name.ToLowerInvariant()))
//             .ToList();
//     }

//     // ── Q25 (in-memory) ─────────────────────────────────────────
//     public Dictionary<int, Dictionary<string, int>> Q25_CommentHeatMap(List<Comment> comments)
//     {
//         return comments
//             .GroupBy(c => c.PostId)
//             .ToDictionary(
//                 postGroup => postGroup.Key,
//                 postGroup => postGroup
//                     .GroupBy(c => c.AuthorName)
//                     .ToDictionary(
//                         authorGroup => authorGroup.Key,
//                         authorGroup => authorGroup.Count()
//                     )
//             );
//     }
// }
