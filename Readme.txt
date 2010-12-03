Areas of interest

Web.config – The unity configuration was done through configuration file.

ManagedUserLookup.Library.Logging.TraceBehavior implements IInterceptionBehavior which is used by Unity for a custom interception implementation.  The class writes to a logging façade that is part of the library assembly.  The façade writes to the console if the program is #Debug otherwise it would use the EL logging library.  The façade was necessary because the first hit penalty of the logging writer was too expensive for this type of logging and my patience.  

AppCode\UnitySingleton class that houses the container.  This was not setup in page lifecycle because there are services in the web site that need to use the container.

AppCode\SearchData service implementation class that shows usage of unity resolving interfaces.

Js\search\SearchResults.js line 164 Shows usage of the jquery.download plugin to post parameters to the server in an “ajax like” fashion and receive a file from the server. http://www.filamentgroup.com/lab/jquery_plugin_for_requesting_ajax_like_file_downloads/ 

Js\jgrowl.js was used for error message display.  This is different from the blockUI messages used in HCSIS because the messages are non-blocking and (configurably) hide after a period of time.  The message should display if the search button is clicked without entering any parameter values.

Exportgrid.aspx.vb code behind file that takes form values that were passed to it and uses Unity to resolve the correct implementation of IExport.  This shows how unity can be passed an interface and a name to resolve an implementation.

ManagedUserLookup.Library.Extensions.ListConversion – There are extension methods here (ToJsonForjqGrid) that take any IEnumerable(Of T) and convert it to a grid structure based on the property names that are passed.  This is used in the service implementation to get data from the repository and then cleanly convert it to the necessary json format.

ManageUserLookup.Test.UnityMethodInjectionFixture shows how unity would can use method injection to resolve all of a classes dependencies.  This method requires that the method have this attribute <InjectionMethod()>.  Decorating the method is not really ideal for a controller but that seems to be the cleanest way for Unity. The virtual public property would need to be decorated with an attribute as well <Dependency()>.    I’m ignoring constructor injection.
	http://msdn.microsoft.com/en-us/library/ff649447.aspx
	http://msdn.microsoft.com/en-us/library/ff649751.aspx 
