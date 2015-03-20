using System;
using System.IO;
using MyMediaLite.Data;
using MyMediaLite.DataType;
using MyMediaLite.Eval;
using MyMediaLite.IO;
using MyMediaLite.ItemRecommendation;

namespace recommenders
{
	public class ExecuteRecommenders
	{
		public ExecuteRecommenders ()
		{
		}
		public static void Main (string[] args)
		{
			String data_dir = "../../data/";
			int nRec = 20;

			executeBPRMF(nRec, data_dir);
			executeKNN(nRec, data_dir);
		}
		public static void executeKNN(int nRec, String data_dir)
		{

			int position;
			var item_data = ItemData.Read(data_dir + "/newTestItem.tsp");
			// Write the results to a single file.
			Console.WriteLine("\t\tSTART");

			System.IO.StreamWriter ia_results_file = new System.IO.StreamWriter(data_dir + "/results/personalized_KNN_results.tsv");
			System.IO.StreamWriter ia_recommendation_file;
			ia_results_file.WriteLine ("model\tbase\tmetric\tvalue");

			Console.WriteLine(data_dir);

			uint[] k_values = new uint[3] {15, 20, 30};



			var training_data = ItemData.Read(data_dir + "/newTraining.tsp");


			String recommendationString;

			foreach (var this_k in k_values)
			{

				// ITEM KNN
				Console.WriteLine("\tItemKNN_" + this_k);

				var ItemKNN_recommender = new ItemKNN();
				ItemKNN_recommender.Feedback = training_data;
				ItemKNN_recommender.K = this_k;

				Console.WriteLine("\t\tTraining...");
				ItemKNN_recommender.Train();

				recommendationString = "";
				foreach(int user in training_data.AllUsers){
					position = 1;
					var recommendation2 = ItemKNN_recommender.Recommend(user, nRec, null, item_data.AllItems);
					foreach(var recUser in recommendation2){
						//Console.WriteLine(user+"\t"+recUser.Item1+"\t"+position+"\t"+recUser.Item2);
						//ia_recommendation_file.WriteLine(user+"\t"+recUser.Item1+"\t"+position+"\t"+recUser.Item2);
						recommendationString += user+"\t"+recUser.Item1+"\t"+position+"\t"+recUser.Item2+"\n";
						position++;
					}

				}
				ia_recommendation_file = new System.IO.StreamWriter (data_dir+"/KNN/ItemKNN_"+this_k+".txt");
				ia_recommendation_file.WriteLine(recommendationString);
				ia_recommendation_file.Close();



				// USER KNN
				Console.WriteLine("\tUserKNN_" + this_k);

				var UserKNN_recommender = new UserKNN();
				UserKNN_recommender.Feedback = training_data;
				UserKNN_recommender.K = this_k;

				Console.WriteLine("\t\tTraining...");
				UserKNN_recommender.Train();


				recommendationString = "";
				foreach(int user in training_data.AllUsers){
					position = 1;
					var recommendation2 = UserKNN_recommender.Recommend(user, nRec, null, item_data.AllItems);
					foreach(var recUser in recommendation2){
						recommendationString += user+"\t"+recUser.Item1+"\t"+position+"\t"+recUser.Item2+"\n";
						position++;
					}

				}
				ia_recommendation_file = new System.IO.StreamWriter (data_dir+"/KNN/UserKNN_"+this_k+".txt");
				ia_recommendation_file.WriteLine(recommendationString);
				ia_recommendation_file.Close();

			}

			ia_results_file.Close();
			Console.WriteLine("DONE!");
		}

		public static void executeBPRMF(int nRec, String data_dir)
		{
			//var data_dir = "../../data/input/";
			int position;

			// Write the results to a single file.
			System.IO.StreamWriter mf_results_file = new System.IO.StreamWriter(data_dir + "/results/mf_results.tsv");
			System.IO.StreamWriter ia_recommendation_file;

			mf_results_file.WriteLine ("model\tbase\tmetric\tvalue");

			Console.WriteLine(data_dir);
			var item_data = ItemData.Read(data_dir + "/newTestItem.tsp");


			var training_data = ItemData.Read(data_dir + "/newTraining.tsp");

			String recommendationString;

			// Create the Recommenders
			var BPRMF_recommender = new BPRMF();
			BPRMF_recommender.Feedback = training_data;

			float[] learn_rates = new float[] { 0.5f, 0.1f, 0.01f, 0.05f };
			uint[] num_factors = new uint[] {  10, 25, 50, 100 };
			foreach (var this_learn_rate in learn_rates)
			{
				foreach (var this_num_factors in num_factors)
				{
					// Define the hyper parameters
					BPRMF_recommender.LearnRate = this_learn_rate;
					BPRMF_recommender.NumFactors = this_num_factors;

					// Train Recommenders
					Console.WriteLine("\tTraining:");

					Console.WriteLine("\t\tBPRMF_" + this_num_factors + "-" + this_learn_rate);
					BPRMF_recommender.Train();

					recommendationString = "";
					foreach(int user in training_data.AllUsers){
						position = 1;
						var recommendation2 = BPRMF_recommender.Recommend(user, nRec, null, item_data.AllItems);
						foreach(var recUser in recommendation2){

							recommendationString += user+"\t"+recUser.Item1+"\t"+recUser.Item2+"\n";
							position++;
						}

					}
					ia_recommendation_file = new System.IO.StreamWriter (data_dir+"/BPRMF/BPRMF" + this_num_factors+ "-" + this_learn_rate +".txt");
					ia_recommendation_file.WriteLine(recommendationString);
					ia_recommendation_file.Close();

					Console.WriteLine("");
				}
			}

			mf_results_file.Close();
			Console.WriteLine("DONE!");
		}


	}
}

