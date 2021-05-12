// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.Collections;
using SAO.Controls;
using SAO.GameObjects.Resources;
using static System.Windows.Forms.Control;

namespace SAO.GameObjects.Characters
{
    public partial class DialogBoxProvider : IRes
    {
        //------------------------------------------------
        public ControlCollection Father_ControlCollection { get; }
        public Hashtable CharactersHashTable { get; set; }
        public DialogContext Context { get; set; }
        public GameControls.DialogBoxBackGround DialogLabel { get; set; }
        public GameControls.LabelControl CharacterNameLabel { get; set; }
        public GameControls.PictureBoxControl LeftCharacterPicture { get; set; }
        public GameControls.PictureBoxControl RightCharacterPicture { get; set; }
        //public GameControls.PictureBoxControl HexagonPictureBox { get; set; }
        public WotoRes MyRes { get; set; }
        /// <summary>
        /// After the Dialog ended, this event will be raised.
        /// </summary>
        public event DialogEndedEventHandler AfterDialogEndedEvent;
        //------------------------------------------------
        public int CurrentStepOfDialog { get; set; }
        public bool IsRightPictureBoxActive { get; set; }
        public bool InClickedWorking { get; set; }
        //------------------------------------------------
        /// <summary>
        /// this will give you ushort (for charactersCount),
        /// also use it in Hashtable with ushort less than 
        /// this value, after that, you will get the <see cref="Character.CharacterName"/> string,
        /// use this string to get the <see cref="Character"/> object.
        /// for example -> Characters[CharHashTable_CODE + "Kotomine"], it will gives you 
        /// the character object directly.
        /// </summary>
        public const string CharHashTable_CODE  = "Chars_";
        public const string DialogStrings_CODE  = "Dialog_";
        public const string IsRight_CODE        = "IsRight_";
        public const string HexagonImgNameInRes = "HxgnImgFile_Name";
        //------------------------------------------------
#pragma warning disable IDE0028
        /// <summary>
        /// Creating a new DialogBoxProvider.
        /// Writed by ALiwoto :)
        /// All rights reserved.
        /// </summary>
        /// <param name="father_ControlCollectionValue"></param>
        public DialogBoxProvider(ControlCollection father_ControlCollectionValue,
            ref DialogContext dialogContext)
        {
            InClickedWorking                        = false;
            CharactersHashTable                     = new Hashtable();
            CharactersHashTable[CharHashTable_CODE] = 0;
            Father_ControlCollection                = father_ControlCollectionValue;
            Context                                 = dialogContext;
            CurrentStepOfDialog                     = 0;
        }
#pragma warning restore IDE0028
        public void SettingUpDialogWorks()
        {
            char[] myChars = (DialogContext.CharacterNameSeparater +
                DialogContext.LeftOrRightSeparater +
                DialogContext.MainContextSeparater +
                DialogContext.Separater).ToCharArray();

            string[] myStrings = Context.Context.Split(myChars,
                StringSplitOptions.RemoveEmptyEntries);
            for(int i = 0; i < myStrings.Length; i += 4)
            {
                CharactersHashTable[CharHashTable_CODE] = (int)CharactersHashTable[CharHashTable_CODE] + 1;
                CharacterInfo myChar = 
                    new CharacterInfo(myStrings[i] + DialogContext.CharacterNameSeparater +
                    myStrings[i + 1]); 
                CharactersHashTable[CharHashTable_CODE +
                    (int)CharactersHashTable[CharHashTable_CODE]] = myChar.CharacterName;
                if(CharactersHashTable[myChar.CharacterName] == null)
                {
                    CharactersHashTable[myChar.CharacterName] = myChar;
                }
                CharactersHashTable[IsRight_CODE +
                    ((int)CharactersHashTable[CharHashTable_CODE]).ToString()] =
                    myStrings[i + 2] == DialogContext.Right ? true : false;
                CharactersHashTable[DialogStrings_CODE +
                    ((int)CharactersHashTable[CharHashTable_CODE]).ToString()] = myStrings[i + 3];
            }
            InitializeComponent();
        }
        public void CleaningUp()
        {
            Father_ControlCollection.Remove(CharacterNameLabel);
            Father_ControlCollection.Remove(DialogLabel);
            if(Father_ControlCollection.Contains(LeftCharacterPicture))
            {
                Father_ControlCollection.Remove(LeftCharacterPicture);
            }
            if (Father_ControlCollection.Contains(RightCharacterPicture))
            {
                Father_ControlCollection.Remove(LeftCharacterPicture);
            }
            //---------------------------------
            CharacterNameLabel.Dispose();
            DialogLabel.Dispose();
            CharacterNameLabel  = null;
            DialogLabel         = null;
            if(LeftCharacterPicture != null)
            {
                LeftCharacterPicture.Dispose();
                LeftCharacterPicture = null;
            }
            if(RightCharacterPicture != null)
            {
                RightCharacterPicture.Dispose();
                RightCharacterPicture = null;
            }
            GC.Collect();
        }
    }
}
