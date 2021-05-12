// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.


namespace WotoProvider
{
    public class WotoCreation
    {
        //-------------------------------------------------
        #region Constants Region
        private const string defaultProcedural =
            "-- { = + ## _ woto _ ## + = } --";
        #endregion
        //-------------------------------------------------
        #region Properties Region
        public string Procedural { get; }
        #endregion
        //-------------------------------------------------
        #region Constructors Region
        private WotoCreation()
        {
            Procedural = defaultProcedural;
        }
        #endregion
        //-------------------------------------------------
        #region static Methods Region
        /// <summary>
        /// Generate a new WotoCreation.
        /// </summary>
        /// <returns></returns>
        public static WotoCreation GenerateWotoCreation()
        {
            return new WotoCreation()
            {

            };
        }
        #endregion
        //-------------------------------------------------
    }
}
