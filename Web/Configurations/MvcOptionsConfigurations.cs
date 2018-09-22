using AutoMapper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Filters;

namespace Web.Configurations
{
    public class MvcOptionsConfigurations
    {
        public static MvcOptions ConfigureMvcOptions(this MvcOptions options, IConfiguration configuration, IServiceCollection services)
        {
            //options..ConfigureFilters(configuration, services);
            //options.ConfigureModelinders();

            return options;
        }

        public static MvcOptions ConfigureFilters(this MvcOptions options, IConfiguration configuration, IServiceCollection services)
        {
            //IConfigurationSection tokenFixoHost = configuration.GetSection(appSettingsTokenFixoHost);
            //IConfigurationSection ipRangeHost = configuration.GetSection(appSettingsIpRangeHost);

            options.Filters.Add(new ToggleAuthorizeFilter());

            //options.Filters.Add(new TokenAndIpAuthorizeFilter(new Autenticador(services, configuration), null, tokenFixoHost.Value));
            //options.Filters.Add(new ConfigBaseRequestMessageFilter());
            //options.Filters.Add(new ValidateBaseRequestMessageFilter());

            return options;
        }

        //public static MvcOptions ConfigureModelinders(this MvcOptions options)
        //{
        //    options.ModelBinderProviders.Insert(0, new CurrentCultureDateTimeBinderProvider());
        //    options.ModelBinderProviders.Insert(0, new CurrentCultureDecimalBinderProvider());

        //    return options;
        //}

        //public static MvcJsonOptions ConfigureMvcJsonOptions(this MvcJsonOptions options, IConfiguration configuration)
        //{
        //    return options.ConfigureSerializersSetttings();
        //}

        //public static MvcJsonOptions ConfigureSerializersSetttings(this MvcJsonOptions options)
        //{
        //    JsonSerializerSettings settings = options.SerializerSettings;

        //    options.SerializerSettings.Converters.Add(new JsonDecimalConverterHelper());
        //    options.SerializerSettings.Converters.Add(new JsonDatetimeConverterHelper());

        //    return options;
        //}
    }
}
