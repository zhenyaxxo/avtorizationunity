using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropdownScript : MonoBehaviour
{
    public Dropdown m_DropdownToSearch;
    public InputField m_SearchField;

    [SerializeField] 
    private List<Dropdown.OptionData> m_DropdownOptions;
 
    private void Awake()
    {
        m_SearchField.onValueChanged.AddListener(SearchDropdown);
        m_DropdownOptions = m_DropdownToSearch.options;
    }
 
    private void SearchDropdown(string _search)
    {
 
        m_DropdownToSearch.options = m_DropdownOptions.FindAll(options => options.text.ToLower().IndexOf
            (_search.ToLower()) >= 0);
        
        m_DropdownToSearch.Hide();
        m_DropdownToSearch.Show();
        m_SearchField.Select();
        
    }
    private void Start() {
        m_DropdownToSearch.onValueChanged.AddListener(delegate {
                DropdownValueChanged(m_DropdownToSearch);
            });
        
    }
    private void Update() {
       if(m_SearchField.isFocused == true)
       {
           if(m_SearchField.text != ""){
            m_DropdownToSearch.Show();   
            m_SearchField.Select();
           }
       }
    }

    void DropdownValueChanged(Dropdown change)
    {
        m_SearchField.text = m_DropdownToSearch.options[m_DropdownToSearch.value].text;
        
    }

    private void LateUpdate()
    {
        m_SearchField.MoveTextEnd(true);
    }
}