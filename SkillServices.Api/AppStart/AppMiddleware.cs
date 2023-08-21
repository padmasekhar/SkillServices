using SkillServices.Api.Constants;

namespace SkillServices.Api.AppStart
{
    public static class AppMiddleware
    {
        public static void AddMiddlewares(this WebApplication app, IConfiguration configuration)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.OAuthClientId(configuration["SwaggerAzureAd:ClientId"]);
                c.OAuthUsePkce();
                c.OAuthScopeSeparator(" "); //It is requried only when there are more then one scope exists. in our case we have only one scope and not requried

            });

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(AppConstants.SKILL_CENTRAL_CORE_POLICY);

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.UseMiddleware(typeof(AppLogHandlerMiddleware));
            app.MapFallbackToFile("index.html");
            app.Run();
        }
    }
}
