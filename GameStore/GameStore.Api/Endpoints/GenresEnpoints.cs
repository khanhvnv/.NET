using System;
using GameStore.Api.Data;
using GameStore.Api.GameMapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints;

public static class GenresEnpoints
{
    public static RouteGroupBuilder MapGenresEndpointts(this WebApplication app)
    {
        var group = app.MapGroup("genres");
        group.MapGet("/", async(GameStoreContext dbContext) =>
            await dbContext.Genres
                            .Select(genre => genre.ToDto())
                            .AsNoTracking()
                            .ToListAsync());
        return group;
    }
}
