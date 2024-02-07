using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.IO;
using Microsoft.Data.Sqlite;
using System.Windows.Forms;

namespace WS_Collector
{
    class DataManager
    {
        static string dbPath = Path.Combine(Application.StartupPath, "WSDBFull.db");
        string connectionString = $"Data Source={dbPath};";

        public DataManager()
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "",
                Database = "",
                UserID = "",
                Password = "",
                SslMode = MySqlSslMode.Required,
                SslCa = "",
            };
        }

        public List<Card> RetrieveAllCards()
        {
            List<Card> cards = new List<Card>();

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                // Construct a SQL query that searches multiple columns
                var query = @"SELECT * FROM fullCardData";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Card card = new Card
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                CardName = reader.IsDBNull(reader.GetOrdinal("CardName")) ? null : reader["CardName"].ToString(),
                                CardNumber = reader.IsDBNull(reader.GetOrdinal("CardNumber")) ? null : reader["CardNumber"].ToString(),
                                Expansion = reader.IsDBNull(reader.GetOrdinal("Expansion")) ? null : reader["Expansion"].ToString(),
                                CardType = reader.IsDBNull(reader.GetOrdinal("CardType")) ? null : reader["CardType"].ToString(),
                                Level = reader.IsDBNull(reader.GetOrdinal("Level")) ? 0 : reader.GetInt32(reader.GetOrdinal("Level")),
                                Power = reader.IsDBNull(reader.GetOrdinal("Power")) ? 0 : reader.GetInt32(reader.GetOrdinal("Power")),
                                Soul = reader.IsDBNull(reader.GetOrdinal("Soul")) ? null : reader["Soul"].ToString(),
                                Rarity = reader.IsDBNull(reader.GetOrdinal("Rarity")) ? null : reader["Rarity"].ToString(),
                                Trigger = reader.IsDBNull(reader.GetOrdinal("Trigger")) ? null : reader["Trigger"].ToString(),
                                SpecialAttribute = reader.IsDBNull(reader.GetOrdinal("SpecialAttribute")) ? null : reader["SpecialAttribute"].ToString(),
                                FlavorText = reader.IsDBNull(reader.GetOrdinal("FlavorText")) ? null : reader["FlavorText"].ToString(),
                                CardText = reader.IsDBNull(reader.GetOrdinal("CardText")) ? null : reader["CardText"].ToString(),
                                ImageLink = reader.IsDBNull(reader.GetOrdinal("ImageLink")) ? null : reader["ImageLink"].ToString(),
                                CardImage = null // Assuming this is handled elsewhere if there's binary data to be converted to an image
                            };

                            // Handling binary image data
                            if (!reader.IsDBNull(reader.GetOrdinal("BinaryImageData")))
                            {
                                byte[] binaryImageData = (byte[])reader["BinaryImageData"];
                                using (MemoryStream ms = new MemoryStream(binaryImageData))
                                {
                                    card.CardImage = Image.FromStream(ms); // Assuming CardImage is of type Image
                                }
                            }
                            // Optional: else part for setting a default image or leave as null

                            cards.Add(card); // Add the card to the list
                        }
                    }
                }
            }

            return cards;
        }

        public List<Card> RetrieveCardsChunk(int offset, int limit)
        {
            List<Card> cards = new List<Card>();

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                // Adjusted SQL query to include LIMIT and OFFSET for chunked data retrieval
                var query = @"SELECT * FROM fullCardData LIMIT @limit OFFSET @offset";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    // Set the parameters for LIMIT and OFFSET
                    command.Parameters.AddWithValue("@limit", limit);
                    command.Parameters.AddWithValue("@offset", offset);

                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Card card = new Card
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                CardName = reader.IsDBNull(reader.GetOrdinal("CardName")) ? null : reader["CardName"].ToString(),
                                CardNumber = reader.IsDBNull(reader.GetOrdinal("CardNumber")) ? null : reader["CardNumber"].ToString(),
                                Expansion = reader.IsDBNull(reader.GetOrdinal("Expansion")) ? null : reader["Expansion"].ToString(),
                                CardType = reader.IsDBNull(reader.GetOrdinal("CardType")) ? null : reader["CardType"].ToString(),
                                Level = reader.IsDBNull(reader.GetOrdinal("Level")) ? 0 : reader.GetInt32(reader.GetOrdinal("Level")),
                                Power = reader.IsDBNull(reader.GetOrdinal("Power")) ? 0 : reader.GetInt32(reader.GetOrdinal("Power")),
                                Soul = reader.IsDBNull(reader.GetOrdinal("Soul")) ? null : reader["Soul"].ToString(),
                                Rarity = reader.IsDBNull(reader.GetOrdinal("Rarity")) ? null : reader["Rarity"].ToString(),
                                Trigger = reader.IsDBNull(reader.GetOrdinal("Trigger")) ? null : reader["Trigger"].ToString(),
                                SpecialAttribute = reader.IsDBNull(reader.GetOrdinal("SpecialAttribute")) ? null : reader["SpecialAttribute"].ToString(),
                                FlavorText = reader.IsDBNull(reader.GetOrdinal("FlavorText")) ? null : reader["FlavorText"].ToString(),
                                CardText = reader.IsDBNull(reader.GetOrdinal("CardText")) ? null : reader["CardText"].ToString(),
                                ImageLink = reader.IsDBNull(reader.GetOrdinal("ImageLink")) ? null : reader["ImageLink"].ToString(),
                                CardImage = null
                            };

                            if (!reader.IsDBNull(reader.GetOrdinal("BinaryImageData")))
                            {
                                byte[] binaryImageData = (byte[])reader["BinaryImageData"];
                                using (MemoryStream ms = new MemoryStream(binaryImageData))
                                {
                                    card.CardImage = Image.FromStream(ms);
                                }
                            }

                            cards.Add(card);
                        }
                    }
                }
            }

            return cards;
        }

        public List<Card> SearchCards(string searchText)
        {
            List<Card> cards = new List<Card>();

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                // Construct a SQL query that searches multiple columns
                var query = @"
                            SELECT * FROM fullCardData 
                            WHERE ID LIKE @searchText 
                               OR CardName LIKE @searchText 
                               OR CardNumber LIKE @searchText 
                               OR Expansion LIKE @searchText 
                               OR CardType LIKE @searchText 
                               OR Level LIKE @searchText 
                               OR Power LIKE @searchText 
                               OR Soul LIKE @searchText 
                               OR Rarity LIKE @searchText 
                               OR Trigger LIKE @searchText 
                               OR SpecialAttribute LIKE @searchText 
                               OR FlavorText LIKE @searchText 
                               OR CardText LIKE @searchText";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    // Use the '%' wildcard to find any matches that contain the searchText
                    command.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Card card = new Card
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                CardName = reader.IsDBNull(reader.GetOrdinal("CardName")) ? null : reader["CardName"].ToString(),
                                CardNumber = reader.IsDBNull(reader.GetOrdinal("CardNumber")) ? null : reader["CardNumber"].ToString(),
                                Expansion = reader.IsDBNull(reader.GetOrdinal("Expansion")) ? null : reader["Expansion"].ToString(),
                                CardType = reader.IsDBNull(reader.GetOrdinal("CardType")) ? null : reader["CardType"].ToString(),
                                Level = reader.IsDBNull(reader.GetOrdinal("Level")) ? 0 : reader.GetInt32(reader.GetOrdinal("Level")),
                                Power = reader.IsDBNull(reader.GetOrdinal("Power")) ? 0 : reader.GetInt32(reader.GetOrdinal("Power")),
                                Soul = reader.IsDBNull(reader.GetOrdinal("Soul")) ? null : reader["Soul"].ToString(),
                                Rarity = reader.IsDBNull(reader.GetOrdinal("Rarity")) ? null : reader["Rarity"].ToString(),
                                Trigger = reader.IsDBNull(reader.GetOrdinal("Trigger")) ? null : reader["Trigger"].ToString(),
                                SpecialAttribute = reader.IsDBNull(reader.GetOrdinal("SpecialAttribute")) ? null : reader["SpecialAttribute"].ToString(),
                                FlavorText = reader.IsDBNull(reader.GetOrdinal("FlavorText")) ? null : reader["FlavorText"].ToString(),
                                CardText = reader.IsDBNull(reader.GetOrdinal("CardText")) ? null : reader["CardText"].ToString(),
                                ImageLink = reader.IsDBNull(reader.GetOrdinal("ImageLink")) ? null : reader["ImageLink"].ToString(),
                                CardImage = null // Assuming this is handled elsewhere if there's binary data to be converted to an image
                            };

                            // Handling binary image data
                            if (!reader.IsDBNull(reader.GetOrdinal("BinaryImageData")))
                            {
                                byte[] binaryImageData = (byte[])reader["BinaryImageData"];
                                using (MemoryStream ms = new MemoryStream(binaryImageData))
                                {
                                    card.CardImage = Image.FromStream(ms); // Assuming CardImage is of type Image
                                }
                            }
                            // Optional: else part for setting a default image or leave as null

                            cards.Add(card); // Add the card to the list
                        }
                    }
                }
            }

            return cards;
        }

        public List<Card> SearchCardsInCollection(string searchText, string gCollectionFilePath)
        {
            List<Card> cards = new List<Card>();

            // Read IDs from file
            List<string> validIds = new List<string>();
            if (File.Exists(gCollectionFilePath))
            {
                validIds = File.ReadAllLines(gCollectionFilePath)
                               .Where(line => !string.IsNullOrWhiteSpace(line))
                               .ToList();
            }

            // Convert the list of IDs into a comma-separated string for the SQL query
            string ids = string.Join(",", validIds.Select(id => $"'{id.Trim()}'"));

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                // Modify the query to filter by IDs from the file
                var query = $@"
                        SELECT * FROM fullCardData 
                        WHERE ID IN ({ids}) AND (
                            ID LIKE @searchText 
                            OR CardName LIKE @searchText 
                            OR CardNumber LIKE @searchText 
                            OR Expansion LIKE @searchText 
                            OR CardType LIKE @searchText 
                            OR Level LIKE @searchText 
                            OR Power LIKE @searchText 
                            OR Soul LIKE @searchText 
                            OR Rarity LIKE @searchText 
                            OR Trigger LIKE @searchText 
                            OR SpecialAttribute LIKE @searchText 
                            OR FlavorText LIKE @searchText 
                            OR CardText LIKE @searchText
                        )";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Card card = new Card
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                CardName = reader.IsDBNull(reader.GetOrdinal("CardName")) ? null : reader["CardName"].ToString(),
                                CardNumber = reader.IsDBNull(reader.GetOrdinal("CardNumber")) ? null : reader["CardNumber"].ToString(),
                                Expansion = reader.IsDBNull(reader.GetOrdinal("Expansion")) ? null : reader["Expansion"].ToString(),
                                CardType = reader.IsDBNull(reader.GetOrdinal("CardType")) ? null : reader["CardType"].ToString(),
                                Level = reader.IsDBNull(reader.GetOrdinal("Level")) ? 0 : reader.GetInt32(reader.GetOrdinal("Level")),
                                Power = reader.IsDBNull(reader.GetOrdinal("Power")) ? 0 : reader.GetInt32(reader.GetOrdinal("Power")),
                                Soul = reader.IsDBNull(reader.GetOrdinal("Soul")) ? null : reader["Soul"].ToString(),
                                Rarity = reader.IsDBNull(reader.GetOrdinal("Rarity")) ? null : reader["Rarity"].ToString(),
                                Trigger = reader.IsDBNull(reader.GetOrdinal("Trigger")) ? null : reader["Trigger"].ToString(),
                                SpecialAttribute = reader.IsDBNull(reader.GetOrdinal("SpecialAttribute")) ? null : reader["SpecialAttribute"].ToString(),
                                FlavorText = reader.IsDBNull(reader.GetOrdinal("FlavorText")) ? null : reader["FlavorText"].ToString(),
                                CardText = reader.IsDBNull(reader.GetOrdinal("CardText")) ? null : reader["CardText"].ToString(),
                                ImageLink = reader.IsDBNull(reader.GetOrdinal("ImageLink")) ? null : reader["ImageLink"].ToString(),
                                CardImage = null // Assuming this is handled elsewhere if there's binary data to be converted to an image
                            };

                            // Handling binary image data
                            if (!reader.IsDBNull(reader.GetOrdinal("BinaryImageData")))
                            {
                                byte[] binaryImageData = (byte[])reader["BinaryImageData"];
                                using (MemoryStream ms = new MemoryStream(binaryImageData))
                                {
                                    card.CardImage = Image.FromStream(ms); // Assuming CardImage is of type Image
                                }
                            }
                            // Optional: else part for setting a default image or leave as null

                            cards.Add(card); // Add the card to the list
                        }
                    }
                }
            }

            return cards;
        }

        public List<Card> GetCardsByExpansion(string expansion)
        {
            List<Card> cards = new List<Card>();

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                
                connection.Open();

                using (SqliteCommand command = new SqliteCommand("SELECT * FROM fullCardData WHERE Expansion = @expansion", connection))
                {
                    command.Parameters.AddWithValue("@expansion", expansion);
                    // SQLite uses a default command timeout of 30 seconds, adjust as needed

                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())  // Process each row
                        {
                            Card card = new Card
                            {
                                ID = reader["ID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ID"]),
                                CardName = reader["CardName"] == DBNull.Value ? null : reader["CardName"].ToString(),
                                CardNumber = reader["CardNumber"] == DBNull.Value ? null : reader["CardNumber"].ToString(),
                                Expansion = reader["Expansion"] == DBNull.Value ? null : reader["Expansion"].ToString(),
                                CardType = reader["CardType"] == DBNull.Value ? null : reader["CardType"].ToString(),
                                Level = reader["Level"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Level"]),
                                Power = reader["Power"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Power"]),
                                Soul = reader["Soul"] == DBNull.Value ? null : reader["Soul"].ToString(),
                                Rarity = reader["Rarity"] == DBNull.Value ? null : reader["Rarity"].ToString(),
                                Trigger = reader["Trigger"] == DBNull.Value ? null : reader["Trigger"].ToString(),
                                SpecialAttribute = reader["SpecialAttribute"] == DBNull.Value ? null : reader["SpecialAttribute"].ToString(),
                                FlavorText = reader["FlavorText"] == DBNull.Value ? null : reader["FlavorText"].ToString(),
                                CardText = reader["CardText"] == DBNull.Value ? null : reader["CardText"].ToString(),
                                ImageLink = reader["ImageLink"] == DBNull.Value ? null : reader["ImageLink"].ToString(),
                                CardImage = null // Initialize CardImage as null
                            };

                            if (reader["BinaryImageData"] != DBNull.Value)
                            {
                                byte[] binaryImageData = (byte[])reader["BinaryImageData"];
                                using (MemoryStream ms = new MemoryStream(binaryImageData))
                                {
                                    card.CardImage = Image.FromStream(ms); // Assuming CardImage is of type Image
                                }
                            }
                            // else part for setting a default image or leave as null

                            cards.Add(card); // Add the card to the list
                        }
                    }
                }
            }

            return cards;
        }

        public List<Card> GetCardsBySeries(string seriesIdentifiers)
        {
            List<Card> cards = new List<Card>();

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                // Split the seriesIdentifiers string by commas to support multiple identifiers
                var identifiers = seriesIdentifiers.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                           .Select(id => id.Trim()) // Trim whitespace
                           .ToList();

                var likeClauses = identifiers.Select(id => $"CardNumber LIKE '{id}/%'");
                var query = $"SELECT * FROM fullCardData WHERE {string.Join(" OR ", likeClauses)}";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    // No need to add parameters here since we're directly constructing the query
                    // Be cautious of SQL injection; this approach assumes seriesIdentifiers come from a controlled source

                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())  // Process each row
                        {
                            Card card = new Card
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                CardName = reader.IsDBNull(reader.GetOrdinal("CardName")) ? null : reader["CardName"].ToString(),
                                CardNumber = reader.IsDBNull(reader.GetOrdinal("CardNumber")) ? null : reader["CardNumber"].ToString(),
                                Expansion = reader.IsDBNull(reader.GetOrdinal("Expansion")) ? null : reader["Expansion"].ToString(),
                                CardType = reader.IsDBNull(reader.GetOrdinal("CardType")) ? null : reader["CardType"].ToString(),
                                Level = reader.IsDBNull(reader.GetOrdinal("Level")) ? 0 : reader.GetInt32(reader.GetOrdinal("Level")),
                                Power = reader.IsDBNull(reader.GetOrdinal("Power")) ? 0 : reader.GetInt32(reader.GetOrdinal("Power")),
                                Soul = reader.IsDBNull(reader.GetOrdinal("Soul")) ? null : reader["Soul"].ToString(),
                                Rarity = reader.IsDBNull(reader.GetOrdinal("Rarity")) ? null : reader["Rarity"].ToString(),
                                Trigger = reader.IsDBNull(reader.GetOrdinal("Trigger")) ? null : reader["Trigger"].ToString(),
                                SpecialAttribute = reader.IsDBNull(reader.GetOrdinal("SpecialAttribute")) ? null : reader["SpecialAttribute"].ToString(),
                                FlavorText = reader.IsDBNull(reader.GetOrdinal("FlavorText")) ? null : reader["FlavorText"].ToString(),
                                CardText = reader.IsDBNull(reader.GetOrdinal("CardText")) ? null : reader["CardText"].ToString(),
                                ImageLink = reader.IsDBNull(reader.GetOrdinal("ImageLink")) ? null : reader["ImageLink"].ToString(),
                                CardImage = null // Assuming this is handled elsewhere if there's binary data to be converted to an image
                            };

                            if (!reader.IsDBNull(reader.GetOrdinal("BinaryImageData")))
                            {
                                byte[] binaryImageData = (byte[])reader["BinaryImageData"];
                                using (MemoryStream ms = new MemoryStream(binaryImageData))
                                {
                                    card.CardImage = Image.FromStream(ms); // Assuming CardImage is of type Image
                                }
                            }

                            cards.Add(card); // Add the card to the list
                        }
                    }
                }
            }

            return cards;
        }

        public Card GetCardById(string cardId)
        {

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM fullCardData WHERE ID = @CardId";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    // Use parameterized query to prevent SQL injection
                    command.Parameters.AddWithValue("@CardId", cardId);

                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Assuming ID is a unique identifier, there should only be one row
                        {
                            Card card = new Card
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                CardName = reader.IsDBNull(reader.GetOrdinal("CardName")) ? null : reader["CardName"].ToString(),
                                CardNumber = reader.IsDBNull(reader.GetOrdinal("CardNumber")) ? null : reader["CardNumber"].ToString(),
                                Expansion = reader.IsDBNull(reader.GetOrdinal("Expansion")) ? null : reader["Expansion"].ToString(),
                                CardType = reader.IsDBNull(reader.GetOrdinal("CardType")) ? null : reader["CardType"].ToString(),
                                Level = reader.IsDBNull(reader.GetOrdinal("Level")) ? 0 : reader.GetInt32(reader.GetOrdinal("Level")),
                                Power = reader.IsDBNull(reader.GetOrdinal("Power")) ? 0 : reader.GetInt32(reader.GetOrdinal("Power")),
                                Soul = reader.IsDBNull(reader.GetOrdinal("Soul")) ? null : reader["Soul"].ToString(),
                                Rarity = reader.IsDBNull(reader.GetOrdinal("Rarity")) ? null : reader["Rarity"].ToString(),
                                Trigger = reader.IsDBNull(reader.GetOrdinal("Trigger")) ? null : reader["Trigger"].ToString(),
                                SpecialAttribute = reader.IsDBNull(reader.GetOrdinal("SpecialAttribute")) ? null : reader["SpecialAttribute"].ToString(),
                                FlavorText = reader.IsDBNull(reader.GetOrdinal("FlavorText")) ? null : reader["FlavorText"].ToString(),
                                CardText = reader.IsDBNull(reader.GetOrdinal("CardText")) ? null : reader["CardText"].ToString(),
                                ImageLink = reader.IsDBNull(reader.GetOrdinal("ImageLink")) ? null : reader["ImageLink"].ToString(),
                                CardImage = null // Assuming this is handled elsewhere if there's binary data to be converted to an image
                            };

                            if (!reader.IsDBNull(reader.GetOrdinal("BinaryImageData")))
                            {
                                byte[] binaryImageData = (byte[])reader["BinaryImageData"];
                                using (MemoryStream ms = new MemoryStream(binaryImageData))
                                {
                                    card.CardImage = Image.FromStream(ms); // Assuming CardImage is of type Image
                                }
                            }

                            return card; // Return the card as soon as it's found
                        }
                    }
                }
            }

            return null; // Return null if no card is found with the given ID
        }

        public List<Card> GetCardsByFilters(string seriesIdentifiers, string cardType = "", string power = "", string level = "", string soul = "", string cardId = "", string rarity = "", string expansion = "", string trigger = "")
        {
            List<Card> cards = new List<Card>();

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var identifiers = seriesIdentifiers.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(id => id.Trim())
                                   .ToList();

                // Grouping series identifiers with OR
                var seriesConditions = identifiers.Select((id, index) => $"CardNumber LIKE @idPrefix{index} || '%'")
                                                  .ToList();

                var seriesConditionGroup = $"({string.Join(" OR ", seriesConditions)})";

                var conditions = new List<string> { seriesConditionGroup };

                // Building the WHERE clause dynamically based on filters
                //var conditions = identifiers.Select(id => $"CardNumber LIKE @idPrefix || '%'").ToList();

                if (!string.IsNullOrWhiteSpace(cardType)) conditions.Add("CardType = @cardType");
                if (!string.IsNullOrWhiteSpace(power)) conditions.Add("Power = @power");
                if (!string.IsNullOrWhiteSpace(level)) conditions.Add("Level = @level");
                if (!string.IsNullOrWhiteSpace(soul)) conditions.Add("Soul = @soul");
                if (!string.IsNullOrWhiteSpace(cardId)) conditions.Add("ID = @cardId");
                if (!string.IsNullOrWhiteSpace(rarity)) conditions.Add("Rarity = @rarity");
                if (!string.IsNullOrWhiteSpace(expansion)) conditions.Add("Expansion = @expansion");
                if (!string.IsNullOrWhiteSpace(trigger)) conditions.Add("Trigger = @trigger");

                var query = $"SELECT * FROM fullCardData WHERE {string.Join(" AND ", conditions)}";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    // Setting the parameters for the SQL query
                    // Setting the parameters for the SQL query, ensuring unique placeholders for series identifiers
                    for (int i = 0; i < identifiers.Count; i++)
                    {
                        command.Parameters.AddWithValue($"@idPrefix{i}", identifiers[i] + "%");
                    }

                    if (!string.IsNullOrWhiteSpace(cardType)) command.Parameters.AddWithValue("@cardType", cardType);
                    if (!string.IsNullOrWhiteSpace(power)) command.Parameters.AddWithValue("@power", power);
                    if (!string.IsNullOrWhiteSpace(level)) command.Parameters.AddWithValue("@level", level);
                    if (!string.IsNullOrWhiteSpace(soul)) command.Parameters.AddWithValue("@soul", soul);
                    if (!string.IsNullOrWhiteSpace(cardId)) command.Parameters.AddWithValue("@cardId", cardId);
                    if (!string.IsNullOrWhiteSpace(rarity)) command.Parameters.AddWithValue("@rarity", rarity);
                    if (!string.IsNullOrWhiteSpace(expansion)) command.Parameters.AddWithValue("@expansion", expansion);
                    if (!string.IsNullOrWhiteSpace(trigger)) command.Parameters.AddWithValue("@trigger", trigger);

                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Card card = new Card
                            {
                                // Populate card fields from reader
                                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                CardName = reader["CardName"].ToString(),
                                CardNumber = reader["CardNumber"].ToString(),
                                Expansion = reader["Expansion"].ToString(),
                                CardType = reader["CardType"].ToString(),
                                Level = reader.IsDBNull(reader.GetOrdinal("Level")) ? 0 : Convert.ToInt32(reader["Level"]),
                                Power = reader.IsDBNull(reader.GetOrdinal("Power")) ? 0 : Convert.ToInt32(reader["Power"]),
                                Soul = reader["Soul"].ToString(),
                                Rarity = reader["Rarity"].ToString(),
                                Trigger = reader["Trigger"].ToString(),
                                SpecialAttribute = reader["SpecialAttribute"].ToString(),
                                FlavorText = reader["FlavorText"].ToString(),
                                CardText = reader["CardText"].ToString(),
                                ImageLink = reader["ImageLink"].ToString(),
                                CardImage = null // Assuming handling of binary data elsewhere
                            };

                            // Handling BinaryImageData for CardImage if present
                            if (!reader.IsDBNull(reader.GetOrdinal("BinaryImageData")))
                            {
                                byte[] binaryImageData = (byte[])reader["BinaryImageData"];
                                using (MemoryStream ms = new MemoryStream(binaryImageData))
                                {
                                    card.CardImage = Image.FromStream(ms); // Assuming CardImage is of type Image
                                }
                            }

                            cards.Add(card);
                        }
                    }
                }
            }

            return cards;
        }

        public List<Card> GetCardsByFiltersForCollection(string seriesIdentifiers, string cardType = "", string power = "", string level = "", string soul = "", string cardIds = "", string rarity = "", string expansion = "", string trigger = "")
        {
            List<Card> cards = new List<Card>();

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var identifiers = seriesIdentifiers.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(id => id.Trim())
                                   .ToList();

                // Grouping series identifiers with OR
                var seriesConditions = identifiers.Select((id, index) => $"CardNumber LIKE @idPrefix{index} || '%'")
                                                  .ToList();
                var seriesConditionGroup = $"({string.Join(" OR ", seriesConditions)})";

                var conditions = new List<string> { seriesConditionGroup };

                if (!string.IsNullOrWhiteSpace(cardType)) conditions.Add("CardType = @cardType");
                if (!string.IsNullOrWhiteSpace(power)) conditions.Add("Power = @power");
                if (!string.IsNullOrWhiteSpace(level)) conditions.Add("Level = @level");
                if (!string.IsNullOrWhiteSpace(soul)) conditions.Add("Soul = @soul");

                // Handle multiple cardIds
                if (!string.IsNullOrWhiteSpace(cardIds))
                {
                    var cardIdList = cardIds.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(id => id.Trim()).ToArray();
                    var cardIdParameters = string.Join(", ", cardIdList.Select((id, index) => $"@cardId{index}"));
                    conditions.Add($"ID IN ({cardIdParameters})");
                }

                if (!string.IsNullOrWhiteSpace(rarity)) conditions.Add("Rarity = @rarity");
                if (!string.IsNullOrWhiteSpace(expansion)) conditions.Add("Expansion = @expansion");
                if (!string.IsNullOrWhiteSpace(trigger)) conditions.Add("Trigger = @trigger");

                var query = $"SELECT * FROM fullCardData WHERE {string.Join(" AND ", conditions)}";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    for (int i = 0; i < identifiers.Count; i++)
                    {
                        command.Parameters.AddWithValue($"@idPrefix{i}", identifiers[i] + "%");
                    }

                    if (!string.IsNullOrWhiteSpace(cardType)) command.Parameters.AddWithValue("@cardType", cardType);
                    if (!string.IsNullOrWhiteSpace(power)) command.Parameters.AddWithValue("@power", power);
                    if (!string.IsNullOrWhiteSpace(level)) command.Parameters.AddWithValue("@level", level);
                    if (!string.IsNullOrWhiteSpace(soul)) command.Parameters.AddWithValue("@soul", soul);

                    // Set parameters for multiple cardIds
                    if (!string.IsNullOrWhiteSpace(cardIds))
                    {
                        var cardIdList = cardIds.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                                .Select(id => id.Trim()).ToArray();
                        for (int i = 0; i < cardIdList.Length; i++)
                        {
                            command.Parameters.AddWithValue($"@cardId{i}", cardIdList[i]);
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(rarity)) command.Parameters.AddWithValue("@rarity", rarity);
                    if (!string.IsNullOrWhiteSpace(expansion)) command.Parameters.AddWithValue("@expansion", expansion);
                    if (!string.IsNullOrWhiteSpace(trigger)) command.Parameters.AddWithValue("@trigger", trigger);

                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Card card = new Card
                            {
                                // Populate card fields from reader
                                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                CardName = reader["CardName"].ToString(),
                                CardNumber = reader["CardNumber"].ToString(),
                                Expansion = reader["Expansion"].ToString(),
                                CardType = reader["CardType"].ToString(),
                                Level = reader.IsDBNull(reader.GetOrdinal("Level")) ? 0 : Convert.ToInt32(reader["Level"]),
                                Power = reader.IsDBNull(reader.GetOrdinal("Power")) ? 0 : Convert.ToInt32(reader["Power"]),
                                Soul = reader["Soul"].ToString(),
                                Rarity = reader["Rarity"].ToString(),
                                Trigger = reader["Trigger"].ToString(),
                                SpecialAttribute = reader["SpecialAttribute"].ToString(),
                                FlavorText = reader["FlavorText"].ToString(),
                                CardText = reader["CardText"].ToString(),
                                ImageLink = reader["ImageLink"].ToString(),
                                CardImage = null // Assuming handling of binary data elsewhere
                            };

                            // Handling BinaryImageData for CardImage if present
                            if (!reader.IsDBNull(reader.GetOrdinal("BinaryImageData")))
                            {
                                byte[] binaryImageData = (byte[])reader["BinaryImageData"];
                                using (MemoryStream ms = new MemoryStream(binaryImageData))
                                {
                                    card.CardImage = Image.FromStream(ms); // Assuming CardImage is of type Image
                                }
                            }

                            cards.Add(card);
                        }
                    }
                }
            }

            return cards;
        }
    }
}
