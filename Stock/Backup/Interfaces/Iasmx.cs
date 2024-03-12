using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Stock.BOJ;
using Stock.WSTOOLS;

namespace Stock.WS
{
    interface IAsmx<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vppCritere">Critère de sélection</param>
        /// <returns>clsObjetRetour</returns>
        clsObjetRetour pvgValeurScalaireRequeteCount(clsObjetEnvoi clsObjetEnvoi);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vppCritere">Critère de sélection</param>
        /// <returns>clsObjetRetour</returns>
        clsObjetRetour pvgValeurScalaireRequeteMin(clsObjetEnvoi clsObjetEnvoi);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vppCritere">Critère de sélection</param>
        /// <returns>clsObjetRetour</returns>
        clsObjetRetour pvgValeurScalaireRequeteMax(clsObjetEnvoi clsObjetEnvoi);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vppCritere">Critère de sélection</param>
        /// <returns>clsObjetRetour</returns>
        clsObjetRetour pvgTableLibelle(clsObjetEnvoi clsObjetEnvoi);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clsPays">BusinessObject</param>
        /// <param name="vppCritere">Critère de sélection</param>
        /// <returns>clsObjetRetour</returns>
        clsObjetRetour pvgAjouter(T vppObjet, clsObjetEnvoi clsObjetEnvoi);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vppObjet">Liste d'objet</param>
        /// <param name="vppCritere">Critère de sélection</param>
        /// <returns></returns>
        clsObjetRetour pvgAjouterListe(List<T> vppObjet, clsObjetEnvoi clsObjetEnvoi);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clsPays">BusinessObject</param>
        /// <param name="vppCritere">Critère de modification</param>
        /// <returns>clsObjetRetour</returns>
        clsObjetRetour pvgModifier(T vppObjet, clsObjetEnvoi clsObjetEnvoi);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vppCritere">Critère de suppression</param>
        /// <returns>clsObjetRetour</returns>
        clsObjetRetour pvgSupprimer(clsObjetEnvoi clsObjetEnvoi);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vppCritere">Critère de sélection</param>
        /// <returns>clsObjetRetour</returns>
        clsObjetRetour pvgCharger(clsObjetEnvoi clsObjetEnvoi);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vppCritere">Critère de sélection</param>
        /// <returns>clsObjetRetour</returns>
        clsObjetRetour pvgChargerAPartirDataSet(clsObjetEnvoi clsObjetEnvoi);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vppCritere">Critère de sélection</param>
        /// <returns>clsObjetRetour</returns>
        clsObjetRetour pvgChargerDansDataSet(clsObjetEnvoi clsObjetEnvoi);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vppCritere">Critère de sélection</param>
        /// <returns>clsObjetRetour</returns>
        clsObjetRetour pvgChargerDansDataSetPourCombo(clsObjetEnvoi clsObjetEnvoi);

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="vppChamps"></param>
        ///// <param name="vppChampOrdre"></param>
        ///// <param name="vppCritere"></param>
        ///// <returns></returns>
        //clsObjetRetour pvgInsertIntoDatasetComboOrdre(string vppChamps, string vppChampOrdre, clsObjetEnvoi clsObjetEnvoi);

    }
}

