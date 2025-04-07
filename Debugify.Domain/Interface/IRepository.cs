using Debugify.Domain.Entity;

namespace Debugify.Domain.Interfaces;

public interface IRepository
{
    Task<bool> AddFeatureDebugStep(DebugStepDetails entity);
    Task<IEnumerable<DebugStepDetails>> GetFeatureeDebugSteps(FeatureName featureName);
   // Task<IEnumerable<T>> GetAllAsync();
  //  Task<T?> GetByIdAsync(int id);
}
