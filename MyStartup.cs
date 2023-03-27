using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

public class MyStartup{
    // Sign up services of Application (Dependence Inject)
    public void ConfigureServices(IServiceCollection services)
    {
        //services.AddSingleton
    }
    // Build pipeline (string Middleware)
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        //When an request send, that middleware will analyze address and check file inside folder www.root then to show that file.
        //StaticMiddleware
        //Notice: You must give that middleware on the top to prioritize handle static file first. If you give it last line code, it will not execute. 
        //That middleware set up file static to allow we build in folder default wwwroot
        app.UseStaticFiles();

        //To use middleware Routing, you use following:
        // Request 
        //EndpointRoutingMiddleware
        app.UseRouting();
        // GET /
        app.UseEndpoints(endpoints =>{
            endpoints.MapGet("/", async (context) =>{
                // we need to use npm(node package manage)
                //all the library that we take will save folder node_modules.
            string html = @"
                <!DOCTYPE html>
                <html>
                <head>
                    <meta charset=""UTF-8"">
                    <title>Trang web đầu tiên</title>
                    <link rel=""stylesheet"" href=""/css/bootstrap.min.css"" />
                    <script src=""/js/jquery.min.js""></script>
                    <script src=""/js/popper.min.js""></script>
                    <script src=""/js/bootstrap.min.js""></script>


                </head>
                <body>
                    <nav class=""navbar navbar-expand-lg navbar-dark bg-danger"">
                            <a class=""navbar-brand"" href=""#"">Brand-Logo</a>
                            <button class=""navbar-toggler"" type=""button"" data-toggle=""collapse"" data-target=""#my-nav-bar"" aria-controls=""my-nav-bar"" aria-expanded=""false"" aria-label=""Toggle navigation"">
                                    <span class=""navbar-toggler-icon""></span>
                            </button>
                            <div class=""collapse navbar-collapse"" id=""my-nav-bar"">
                            <ul class=""navbar-nav"">
                                <li class=""nav-item active"">
                                    <a class=""nav-link"" href=""#"">Trang chủ</a>
                                </li>
                            
                                <li class=""nav-item"">
                                    <a class=""nav-link"" href=""#"">Học HTML</a>
                                </li>
                            
                                <li class=""nav-item"">
                                    <a class=""nav-link disabled"" href=""#"">Gửi bài</a>
                                </li>
                        </ul>
                        </div>
                    </nav> 
                    <p class=""display-4 text-danger"">Đây là trang đã có Bootstrap</p>
                </body>
                </html>
                ";
                await context.Response.WriteAsync(html);
            });
        // You can create a lot of endpoint with method GET

                endpoints.MapGet("/about", async (context) =>{
                await context.Response.WriteAsync("Trang gioi thieu");
            });
                endpoints.MapGet("/contact", async (context) =>{
                await context.Response.WriteAsync("Trang lien he");
            });
        });
        // You can create a lot of endpoint with method GET

        //otherwise, have another method. Example:
        //endpoints.MapPost: access to another address with method Post.
        //endpoints.MapPut: access to another address with method Put.
        //endpoints.MapRazorPages: to redirect to Razor Pages
        //Configure middleware to pipeline formation
        // Terminate Middleware
            app.Map("/abc", app1 =>{
            app1.Run(async (context) => {
               await context.Response.WriteAsync("Noi dung tra ve tu abc");
            });
        });
        // //another terminate middleware
        // app.Run(async (conText) => {
        //     //This response will return client
        //    await conText.Response.WriteAsync("Hello this is MyStartUp");
        // });
        // // If you write as like above, The terminate middleware app.Run() which write first will always run first and any terminate behind will worthless.

        // To set page wrong direct, If request wasn't handled by any middleware.
        // StatusCodePages is last middleware in pipeline
        app.UseStatusCodePages();

        //Note all: The any middleware put the first, the request will handle first with that middleware
    }
}