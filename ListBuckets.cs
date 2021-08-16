using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Services;
using Google.Apis.Storage.v1;
using Google.Cloud.Storage.V1;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Google_Download_Report
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button_Process(object sender, EventArgs e)
        {
        /*https://support.google.com/googleplay/android-developer/answer/6135870#export&zippy=%2Cdownload-reports-using-a-command-line-tool%2Cdownload-reports-using-a-client-library-service-account
        *https://stackoverflow.com/questions/49475897/google-cloud-api-service-authorisation-failure-forbidden-access
        *https://cloud.google.com/docs/authentication/production?hl=es#passing_code
        *https://cloud.google.com/storage/docs/reference/libraries
        */
            ListBuckets();
        }
        
        public void ListBuckets(          
           string projectId = "jorgesys-puisor-12",           
           {
             //var storage = StorageClient.Create();                                
             var credential = GoogleCredential.FromFile(@"C:\Data\Development Android\GoogleFinancialReport\jorgesys-puisor-12-8aa7bf5e3daa.json");
             var storage = StorageClient.Create(credential);                

            var buckets = storage.ListBuckets(projectId);
            foreach (var bucket in buckets)
            {
                Console.WriteLine("* bucket: " + bucket.Name);
                //var bucket = storage.CreateBucket(projectId, bucketName);
                // Console.WriteLine($"Created {bucketName}.");                
                Console.WriteLine("bucket Id: " + bucket.Id.ToString());
                Console.WriteLine("bucket Owner: " + bucket.Location.ToString());

                this.lbData.Text = lbData.Text + "*Name: " +bucket.Name + "\n";                
                this.lbData.Text = lbData.Text + "Id: " + bucket.Id.ToString() + "\n";
                this.lbData.Text = lbData.Text + "Location: " + bucket.Location.ToString() + "\n";
                this.lbData.Text = lbData.Text + "Metageneration: " + bucket.Metageneration.ToString() + "\n";
                this.lbData.Text = lbData.Text + "ProjectNumber: " + bucket.ProjectNumber.ToString() + "\n";
                this.lbData.Text = lbData.Text + "StorageClass: " + bucket.StorageClass.ToString() + "\n";
                this.lbData.Text = lbData.Text + "IamConfiguration: " + bucket.IamConfiguration.ToString() + "\n";
                this.lbData.Text = lbData.Text + "TimeCreated: " + bucket.TimeCreated.ToString() + "\n\n";

            }

      
        }

    }
