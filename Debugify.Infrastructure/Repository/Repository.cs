using Debugify.Domain.Interfaces;
using Debugify.Domain.Entity;
using Debugify.Infrastructure.DB;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Logging;

namespace Debugify.Infrastructure.Repositories;

public class Repository : IRepository
{
    private readonly DebugDBContext _context;
    private readonly string _connectionString;
    public readonly ILogger<DebugStepDetails> _logger;
    public Repository(DebugDBContext context,IConfiguration configuration, ILogger<DebugStepDetails> logger)
    {
        _context = context;
        _connectionString = configuration.GetConnectionString("DefaultConnection");
        _logger = logger;
    }
    public SqlConnection CreateConnection() => new SqlConnection(_connectionString);

    public async Task<bool> AddFeatureDebugStep(DebugStepDetails entity)
    {
        try
        {
             _context.DebugStepDetails.Add(entity);
             _context.SaveChanges();
            return true;
        }
        catch (Exception ex) {
            throw new Exception(ex.Message);
            return false;
        }
     
    }

    public async Task<IEnumerable<DebugStepDetails>> GetFeatureeDebugSteps(FeatureName featureName)
    {
        _logger.LogInformation($"Starting to connect the DB{featureName.Name}");
        try
        {
            _logger.LogDebug("Performing database query...");
            DebugStepDetails debugStepDetails = new DebugStepDetails();
            using var connection = CreateConnection();
            string query = @"
                SELECT * 
                FROM DebugStepDetails 
                WHERE FeatureName LIKE @FeatureName 
                   OR IssueDescription LIKE @FeatureName 
                   OR Tags LIKE @FeatureName";

            var parameters = new { FeatureName = $"%{featureName.Name}%" };
            var result = await connection.QueryAsync<DebugStepDetails>(query, parameters);
            return result;


        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while searching debug steps.");
            throw new Exception(ex.Message);
        }
    }

    // public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

    // public async Task<T?> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);
}
