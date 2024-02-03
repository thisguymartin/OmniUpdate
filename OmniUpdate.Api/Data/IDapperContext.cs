namespace OmniUpdate.Api.Data
{
    /**
     * The IDataAccess interface provides methods for loading and saving data.
     */
    public interface IDapperContext
    {
        /**
         * Loads data from the database using the specified stored procedure and parameters.
         * 
         * @param storedProcedure The name of the stored procedure to execute.
         * @param parameters The parameters to pass to the stored procedure.
         * @param connectionId The ID of the database connection to use. Default is "Default".
         * @return A Task object representing the asynchronous operation. The result is an IEnumerable<T> containing the loaded data.
         */
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "Default");

        /**
         * Saves data to the database using the specified stored procedure and parameters.
         * 
         * @param storedProcedure The name of the stored procedure to execute.
         * @param parameters The parameters to pass to the stored procedure.
         * @param connectionId The ID of the database connection to use. Default is "Default".
         * @return A Task object representing the asynchronous operation.
         */
        Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "Default");
    }
}