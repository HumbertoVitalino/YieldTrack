using Application.Interfaces.Repositories;
using Domain;

namespace Infrastructure.Repositories;

public class InvestmentRepository(YieldTrackContext context) : Repository<UserInvestment>(context), IInvestmentRepository
{
}
