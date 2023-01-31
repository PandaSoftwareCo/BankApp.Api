
https://learn.microsoft.com/en-us/aspnet/core/fundamentals/routing?view=aspnetcore-6.0
https://www.c-sharpcorner.com/article/measuring-and-reporting-the-response-time-of-an-asp-net-core-api/
https://www.codeproject.com/Tips/5337523/Response-Time-Header-in-ASP-NET-Core
https://codereview.stackexchange.com/questions/235812/accurately-measure-asp-net-core-3-x-actions-execution-times-web-api-project
http://www.itlec.com/2020/06/timer-custom-header-webapi.html


https://learn.microsoft.com/en-us/aspnet/core/performance/performance-best-practices?view=aspnetcore-6.0
https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-6.0
https://learn.microsoft.com/en-us/aspnet/core/test/middleware?view=aspnetcore-6.0
https://code-maze.com/aspnetcore-webapi-best-practices/
https://stackoverflow.com/questions/41760875/how-to-improve-net-core-web-api-performance

dotnet tool install --global dotnet-ef

dotnet user-secrets init
dotnet user-secrets set ConnectionStrings:Chinook "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Chinook"
dotnet ef dbcontext scaffold Name=ConnectionStrings:Chinook Microsoft.EntityFrameworkCore.SqlServer

drop-database -startupProject BankApp -project BankApp.Data -Context BankApp.Data.Context.BankContext
remove-migration -startupProject BankApp -project BankApp.Data -Context BankApp.Data.Context.BankContext
add-migration Initial -startupProject BankApp.Api -project BankApp.Data -Context BankApp.Data.Context.BankContext
add-migration Identity -startupProject BankApp.Api -project BankApp.Data -Context BankApp.Data.Context.BankContext
update-database -startupProject BankApp.Api -project BankApp.Data -Context BankApp.Data.Context.BankContext

vue create vue-app
manual
router
vuex
unit-testing
3.x
history mode
 $ cd vue-app
 $ npm run serve
npm i vuetify@next @mdi/font

vue create client-app
vue add bootstrap
npm i bootstrap
npm i font-awesome
npm i axios
vue i moment
vue i dayjs
npm i @vuelidate/core @vuelidate/validators
 $ cd client-app
 $ npm run serve
npm i vuetify@next @mdi/font


docker run -d -p 5672:5672 -p 15672:15672 rabbitmq:3-management
Install-Package MassTransit.RabbitMQ


BankApp.Data

Installing:

Microsoft.EntityFrameworkCore.6.0.0
Microsoft.EntityFrameworkCore.Abstractions.6.0.0
Microsoft.EntityFrameworkCore.Analyzers.6.0.0
Microsoft.Extensions.Caching.Abstractions.6.0.0
Microsoft.Extensions.Caching.Memory.6.0.0
Microsoft.Extensions.DependencyInjection.6.0.0
Microsoft.Extensions.DependencyInjection.Abstractions.6.0.0
Microsoft.Extensions.Logging.6.0.0
Microsoft.Extensions.Logging.Abstractions.6.0.0
Microsoft.Extensions.Options.6.0.0
Microsoft.Extensions.Primitives.6.0.0
System.Collections.Immutable.6.0.0
System.Diagnostics.DiagnosticSource.6.0.0
System.Runtime.CompilerServices.Unsafe.6.0.0

BankApp.Data

Installing:

Humanizer.Core.2.8.26
Microsoft.EntityFrameworkCore.Design.6.0.0
Microsoft.EntityFrameworkCore.Relational.6.0.0
Microsoft.Extensions.Configuration.Abstractions.6.0.0

BankApp.Data

Installing:

Microsoft.EntityFrameworkCore.Design.6.0.0

BankApp.Data

Installing:

Microsoft.CSharp.4.5.0
Microsoft.Data.SqlClient.2.1.4
Microsoft.Data.SqlClient.SNI.runtime.2.1.1
Microsoft.EntityFrameworkCore.SqlServer.6.0.0
Microsoft.Identity.Client.4.21.1
Microsoft.IdentityModel.JsonWebTokens.6.8.0
Microsoft.IdentityModel.Logging.6.8.0
Microsoft.IdentityModel.Protocols.6.8.0
Microsoft.IdentityModel.Protocols.OpenIdConnect.6.8.0
Microsoft.IdentityModel.Tokens.6.8.0
Microsoft.NETCore.Platforms.3.1.0
Microsoft.Win32.Registry.4.7.0
Microsoft.Win32.SystemEvents.4.7.0
System.Configuration.ConfigurationManager.4.7.0
System.Drawing.Common.4.7.0
System.IdentityModel.Tokens.Jwt.6.8.0
System.Runtime.Caching.4.7.0
System.Security.AccessControl.4.7.0
System.Security.Cryptography.Cng.4.5.0
System.Security.Cryptography.ProtectedData.4.7.0
System.Security.Permissions.4.7.0
System.Security.Principal.Windows.4.7.0
System.Text.Encoding.CodePages.4.7.0
System.Windows.Extensions.4.7.0

BankApp.Api

Installing:

FluentValidation.11.2.1
FluentValidation.AspNetCore.11.2.2
FluentValidation.DependencyInjectionExtensions.11.2.1

BankApp.Api

Updates:

Microsoft.CSharp.4.5.0 -> Microsoft.CSharp.4.7.0

Installing:

AutoMapper.12.0.0
AutoMapper.Extensions.Microsoft.DependencyInjection.12.0.0

BankApp.Data

Installing:

Microsoft.Extensions.Diagnostics.HealthChecks.Abstractions.6.0.0

BankApp.Api

Installing:

Microsoft.Extensions.Http.6.0.0
Microsoft.Extensions.Http.Polly.6.0.0
Polly.7.2.2
Polly.Extensions.Http.3.0.0

BankApp.Data

Installing:

Dapper.2.0.123

BankApp.Data

Installing:

Dapper.Contrib.2.0.78

BankApp.Api

Installing:

Serilog.2.12.0

BankApp.Api

Installing:

Microsoft.Extensions.Configuration.2.0.0
Microsoft.Extensions.Configuration.Binder.2.0.0
Microsoft.Extensions.DependencyModel.3.0.0
Microsoft.Extensions.FileProviders.Abstractions.3.1.8
Microsoft.Extensions.Hosting.Abstractions.3.1.8
Microsoft.Extensions.Options.ConfigurationExtensions.2.0.0
Serilog.AspNetCore.6.1.0
Serilog.Extensions.Hosting.5.0.1
Serilog.Extensions.Logging.3.1.0
Serilog.Formatting.Compact.1.1.0
Serilog.Settings.Configuration.3.3.0
Serilog.Sinks.Console.4.0.1
Serilog.Sinks.Debug.2.0.0
Serilog.Sinks.File.5.0.0

BankApp.Api

Installing:

Serilog.Sinks.Debug.2.0.0

BankApp.Api

Updates:

Serilog.Sinks.Console.4.0.1 -> Serilog.Sinks.Console.4.1.0

BankApp.Api

Installing:

Serilog.Sinks.File.5.0.0

BankApp.Api

Installing:

Serilog.Enrichers.Environment.2.2.0

BankApp.Api

Installing:

Serilog.Enrichers.Thread.3.1.0

BankApp.Api

Installing:

Serilog.Sinks.Async.1.5.0

BankApp.Api

Updates:

System.Buffers.4.3.0 -> System.Buffers.4.5.0

Installing:

Elasticsearch.Net.7.8.1
Serilog.Formatting.Elasticsearch.8.4.1
Serilog.Sinks.Elasticsearch.8.4.1
Serilog.Sinks.PeriodicBatching.2.1.1

BankApp.Api

Updates:

System.Reflection.TypeExtensions.4.3.0 -> System.Reflection.TypeExtensions.4.7.0

Installing:

Serilog.Exceptions.8.4.0

BankApp.Api

Installing:

Serilog.Enrichers.Process.2.0.2

BankApp.Api

Updates:

Microsoft.Data.SqlClient.2.1.4 -> Microsoft.Data.SqlClient.5.0.1
Microsoft.Data.SqlClient.SNI.runtime.2.1.1 -> Microsoft.Data.SqlClient.SNI.runtime.5.0.1
Microsoft.Extensions.Configuration.2.0.0 -> Microsoft.Extensions.Configuration.6.0.1
Microsoft.Extensions.Configuration.Binder.2.0.0 -> Microsoft.Extensions.Configuration.Binder.6.0.0
Microsoft.Extensions.Options.ConfigurationExtensions.2.0.0 -> Microsoft.Extensions.Options.ConfigurationExtensions.6.0.0
Microsoft.Identity.Client.4.21.1 -> Microsoft.Identity.Client.4.45.0
Microsoft.IdentityModel.JsonWebTokens.6.8.0 -> Microsoft.IdentityModel.JsonWebTokens.6.21.0
Microsoft.IdentityModel.Logging.6.8.0 -> Microsoft.IdentityModel.Logging.6.21.0
Microsoft.IdentityModel.Protocols.6.8.0 -> Microsoft.IdentityModel.Protocols.6.21.0
Microsoft.IdentityModel.Protocols.OpenIdConnect.6.8.0 -> Microsoft.IdentityModel.Protocols.OpenIdConnect.6.21.0
Microsoft.IdentityModel.Tokens.6.8.0 -> Microsoft.IdentityModel.Tokens.6.21.0
Microsoft.NETCore.Platforms.3.1.0 -> Microsoft.NETCore.Platforms.5.0.0
Microsoft.Win32.Registry.4.7.0 -> Microsoft.Win32.Registry.5.0.0
Serilog.Sinks.PeriodicBatching.2.1.1 -> Serilog.Sinks.PeriodicBatching.3.1.0
System.Buffers.4.5.0 -> System.Buffers.4.5.1
System.Configuration.ConfigurationManager.6.0.0 -> System.Configuration.ConfigurationManager.6.0.1
System.IdentityModel.Tokens.Jwt.6.8.0 -> System.IdentityModel.Tokens.Jwt.6.21.0
System.Runtime.Caching.4.7.0 -> System.Runtime.Caching.5.0.0
System.Security.Principal.Windows.4.7.0 -> System.Security.Principal.Windows.5.0.0
System.Text.Encoding.CodePages.4.7.0 -> System.Text.Encoding.CodePages.5.0.0
System.Text.Encodings.Web.4.5.0 -> System.Text.Encodings.Web.4.7.2

Installing:

Azure.Core.1.24.0
Azure.Identity.1.6.0
Microsoft.Identity.Client.Extensions.Msal.2.19.3
Microsoft.IdentityModel.Abstractions.6.21.0
Microsoft.SqlServer.Server.1.0.0
Serilog.Sinks.MSSqlServer.6.0.0
System.Memory.Data.1.0.2
System.Numerics.Vectors.4.5.0

BankApp.Api

Installing:

Microsoft.AspNetCore.Mvc.Versioning.5.0.0

BankApp.Api

Installing:

Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer.5.0.0

BankApp.IntegrationTests

Updates:

System.Buffers.4.3.0 -> System.Buffers.4.5.1
System.Diagnostics.DiagnosticSource.4.3.0 -> System.Diagnostics.DiagnosticSource.6.0.0

Installing:

Microsoft.AspNetCore.Mvc.Testing.6.0.0
Microsoft.AspNetCore.TestHost.6.0.0
Microsoft.Extensions.Configuration.6.0.0
Microsoft.Extensions.Configuration.Abstractions.6.0.0
Microsoft.Extensions.Configuration.Binder.6.0.0
Microsoft.Extensions.Configuration.CommandLine.6.0.0
Microsoft.Extensions.Configuration.EnvironmentVariables.6.0.0
Microsoft.Extensions.Configuration.FileExtensions.6.0.0
Microsoft.Extensions.Configuration.Json.6.0.0
Microsoft.Extensions.Configuration.UserSecrets.6.0.0
Microsoft.Extensions.DependencyInjection.6.0.0
Microsoft.Extensions.DependencyInjection.Abstractions.6.0.0
Microsoft.Extensions.DependencyModel.6.0.0
Microsoft.Extensions.FileProviders.Abstractions.6.0.0
Microsoft.Extensions.FileProviders.Physical.6.0.0
Microsoft.Extensions.FileSystemGlobbing.6.0.0
Microsoft.Extensions.Hosting.6.0.0
Microsoft.Extensions.Hosting.Abstractions.6.0.0
Microsoft.Extensions.Logging.6.0.0
Microsoft.Extensions.Logging.Abstractions.6.0.0
Microsoft.Extensions.Logging.Configuration.6.0.0
Microsoft.Extensions.Logging.Console.6.0.0
Microsoft.Extensions.Logging.Debug.6.0.0
Microsoft.Extensions.Logging.EventLog.6.0.0
Microsoft.Extensions.Logging.EventSource.6.0.0
Microsoft.Extensions.Options.6.0.0
Microsoft.Extensions.Options.ConfigurationExtensions.6.0.0
Microsoft.Extensions.Primitives.6.0.0
System.Diagnostics.EventLog.6.0.0
System.IO.Pipelines.6.0.0
System.Memory.4.5.4
System.Runtime.CompilerServices.Unsafe.6.0.0
System.Text.Encodings.Web.6.0.0
System.Text.Json.6.0.0

BankApp.Api

Installing:

Microsoft.AspNetCore.Authentication.JwtBearer.6.0.0

BankApp.Api

Installing:

Swashbuckle.AspNetCore.SwaggerUI.6.2.3

BankApp.Api

Installing:

Swashbuckle.AspNetCore.Annotations.6.2.3

BankApp.Api

Installing:

Microsoft.Extensions.Http.6.0.0

BankApp.Api

Uninstalling:

Microsoft.Extensions.Http.6.0.0

BankApp.Api

Installing:

Microsoft.EntityFrameworkCore.InMemory.6.0.0

BankApp.Api

Updates:

Microsoft.Extensions.DependencyModel.3.0.0 -> Microsoft.Extensions.DependencyModel.6.0.0
System.Text.Encodings.Web.4.7.2 -> System.Text.Encodings.Web.6.0.0
System.Text.Json.5.0.2 -> System.Text.Json.6.0.0

Installing:

Microsoft.Data.Sqlite.Core.6.0.0
Microsoft.EntityFrameworkCore.Sqlite.6.0.0
Microsoft.EntityFrameworkCore.Sqlite.Core.6.0.0
SQLitePCLRaw.bundle_e_sqlite3.2.0.6
SQLitePCLRaw.core.2.0.6
SQLitePCLRaw.lib.e_sqlite3.2.0.6
SQLitePCLRaw.provider.e_sqlite3.2.0.6

BankApp.UnitTests

Installing:

Castle.Core.5.1.0
Moq.4.18.3

