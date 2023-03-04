namespace OpenFileInExternalApplication
{
    [Command(PackageIds.OpenFileCommand)]
    internal sealed class OpenFileCommand : BaseCommand<OpenFileCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            var docView = await VS.Documents.GetActiveDocumentViewAsync();
            if (docView != null)
            {
                var filePath = docView.FilePath;
                if (filePath != null)
                {
                    var options = await General.GetLiveInstanceAsync();

                    try
                    {
                        var externalApp = Environment.ExpandEnvironmentVariables(options.ExternalApp);
                        var args = filePath;
                        if (!String.IsNullOrEmpty(options.Args))
                        {
                            args = $"{options.Args} {filePath}";
                        }

                        var process = new System.Diagnostics.Process();
                        process.StartInfo.FileName = externalApp;
                        process.StartInfo.Arguments = args;
                        process.Start();
                    }
                    catch (Exception ex)
                    {
                        await VS.MessageBox.ShowErrorAsync("External Application Error", ex.Message);
                    }

                }
            }
        }
    }
}
