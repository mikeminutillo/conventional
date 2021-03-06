﻿using System;
using Conventional.Tests.Helpers.Handlers;
using Conventional.Tests.MoreServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conventional.Tests
{
    [TestClass]
    public class NormalUsage
    {
        private static int _services;
        private static int _handlers;

        [ClassInitialize]
        public static void BecauseOf(TestContext context)
        {
            Conventions.Configure(x =>
            {
                x.Install<Services>(t => _services++);
                x.Install<Handlers>(t => _handlers++);

                x.ScanThisAssembly()
                    .For<Services>()
                    .For<Handlers>()
                    ;

                x.ScanAssemblyContaining<ExternalService>()
                    .For<Services>()
                    ;
            });
        }

        [TestMethod]
        public void FindsServices()
        {
            Assert.AreEqual(3, _services);
        }

        [TestMethod]
        public void FindsHandlers()
        {
            Assert.AreEqual(2, _handlers);
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void DontRunTwice()
        {
            Conventions.Configure(x => { });
        }

        class Services : IConvention
        {
            public bool Matches(Type t)
            {
                return t.Namespace.Contains("Service") 
                    && t.HasInterfaces();
            }
        }

        class Handlers : IConvention
        {
            public bool Matches(Type t)
            {
                return t.ClosesInterface(typeof (IHandler<>));
            }
        }
    }
}
