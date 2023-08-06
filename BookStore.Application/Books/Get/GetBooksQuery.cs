namespace BookStore.Application.Books.Get;
using System;
using System.Collections.Generic;
using BookStore.Domain.Books;
using MediatR;
using Microsoft.AspNetCore.Http;

public class GetBooksQuery : IRequest<(IEnumerable<BookDto> Entries, int Count, int TotalCount)>
{
    public string? Title { get; set; }
    public DateTime? ReleaseDate { get; set; }

    public static bool TryParse(IQueryCollection query, out GetBooksQuery queryObj)
    {
        // Initialize the queryObj to default values
        queryObj = new GetBooksQuery();

        // Try to parse the query parameters and populate the queryObj
        try
        {
            if (query.TryGetValue("Title", out var titleValue) && !string.IsNullOrWhiteSpace(titleValue))
            {
                queryObj.Title = titleValue;
            }

            if (query.TryGetValue(
                    "ReleaseDate",
                    out var releaseDateValue) &&
                DateTime.TryParse(
                    releaseDateValue,
                    out var releaseDate))
            {
                queryObj.ReleaseDate = releaseDate;
            }

            // Return true if parsing is successful
            return true;
        }
        catch
        {
            // Return false if any parsing errors occur
            return false;
        }
    }
}
