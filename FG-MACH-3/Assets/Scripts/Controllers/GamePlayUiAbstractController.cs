using System.Collections.Generic;
using UnityEngine.UI;

namespace Controllers
{
    abstract class GamePlayUiAbstractController : BaseController
    {
        internal void SetActiveButtons(List<Button> buttons)
        {
            foreach (var button in buttons)
            {
                if (button.gameObject.activeSelf)
                {
                    button.gameObject.SetActive(false);
                }
                else
                {
                    button.gameObject.SetActive(true);
                }
            }
        }
    }
}
