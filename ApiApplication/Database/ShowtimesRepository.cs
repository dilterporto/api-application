using ApiApplication.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ApiApplication.Database;

public class ShowtimesRepository : IShowtimesRepository
{
    private readonly CinemaContext _context;
    public ShowtimesRepository(CinemaContext context) 
        => _context = context;

    public ShowtimeEntity Add(ShowtimeEntity showtimeEntity)
    {
        _context.Showtimes.Add(showtimeEntity);
        _context.SaveChanges();

        return showtimeEntity;
    }

    public ShowtimeEntity Delete(int id)
    {
        var showTime = _context.Showtimes.Find(id);
        if (showTime is not null)
            _context.Showtimes.Remove(showTime);
        return showTime;
    }

    public ShowtimeEntity GetByMovie(Func<IQueryable<MovieEntity>, bool> filter) 
        => _context.Showtimes.Include(x => x.Movie).Where((Func<ShowtimeEntity, bool>)filter).FirstOrDefault();

    public IEnumerable<ShowtimeEntity> GetCollection() 
        => GetCollection(null);

    public IEnumerable<ShowtimeEntity> GetCollection(Func<IQueryable<ShowtimeEntity>, bool> filter) 
        => _context.Showtimes.Include(x => x.Movie);

    public ShowtimeEntity Update(ShowtimeEntity showtimeEntity)
    {
        throw new System.NotImplementedException();
    }
}