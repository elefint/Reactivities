using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        // Create a nested class inside surrounding class 
        // Fetching Data is a Query, List.Query
        // Use MediatR interface to make a request (IRequest)
        // Specify what we want to return <List<Activity> (List of activities)
        public class Query : IRequest<List<Activity>> { }

        // Handler Class
        // IRequestHandler with our Query and what we want to return (List of Activities)
        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;

            // Constructor for accessing Datacontext
            // Inject Datacontext context
            public Handler(DataContext context)
            {   // Initialize field from handler
                _context = context;
            }

            // Async method that performs a Task to return a List of Activities
            // Have access to our query (Query request)
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                // Return a list of activities
                return await _context.Activities.ToListAsync();
            }
        }
    }
}