using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PanelVision : MonoBehaviour
{
    List<Panel> OpenedPanelsPile = new List<Panel>();


    public void OpenPanel(Panel slectedPanel)
    {
        if (slectedPanel.IsExclusive)
            OpenedPanelsPile.ForEach(panel => panel.Hide());

        slectedPanel.Open();

        if (!OpenedPanelsPile.Contains(slectedPanel))
            OpenedPanelsPile.Add(slectedPanel);

        if (slectedPanel.PauseGame)
        {
            GameManager.Sgt.Pause();
        }
        else
        {
            GameManager.Sgt.Unpause();
        }
    }


    public void ClosePanel(Panel slectedPanel)
    {
        slectedPanel.Close();
        OpenedPanelsPile.Remove(slectedPanel);

        if (OpenedPanelsPile.Count > 0)
            OpenPanel(OpenedPanelsPile.Last());
        else
        {
            GameManager.Sgt.Unpause();
        }
    }
}
