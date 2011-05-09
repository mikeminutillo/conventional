conventional
============

Conventional is a library for adding type-based conventions to you projects. The simplest way to add the library to your project is with Nuget:
    Install-Package Conventional
Once installed you need to define some Conventions and then Configure the conventions engine:
  class Services : IConvention {
      public bool Matches(Type t) {
          return t.Namespace.Contains("Services");
      }
  }

  //... during app start up
  Conventions.Configure(c => {
      c.Install<Services>(t => IoC.RegisterService(t));

      c.Scan("MyProject.Services").For<Services>();
      c.ScanThisAssembly().For<Services>();
  });