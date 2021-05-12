// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.


namespace WotoProvider.EventHandlers
{
    public class TickHandlerEventArgs<T> : WotoEventArgs
        where T : class
    {
        /// <summary>
        /// my Father.
        /// </summary>
        public T Father { get; }
        //-------------------------------------------------
        public TickHandlerEventArgs(WotoCreation creation, T fatherSender) :
            base(creation)
        {
            Father = fatherSender;
        }
        //-------------------------------------------------
    }
}
