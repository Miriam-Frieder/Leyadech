﻿using leyadech.server.DTO;


namespace leyadech.server.Service
{
    public class VolunteeringService
    {
        List<Volunteering> _allVolunteerings;
        public List<Volunteering> GetAllVolunteerings() => _allVolunteerings;
        public Volunteering GetVolunteeringById(int id) 
        {
            return _allVolunteerings.Where(vol => vol.Id == id)
                .FirstOrDefault<Volunteering>();
        }
        public bool AddVolunteering(Volunteering vol) 
        {
            vol.VolunteeringId=_allVolunteerings.Max(v=>v.VolunteeringId)+1;
        }
        public void SetVolunteeringFields(Volunteering orig,Volunteering newVo)
        {

        }
        public bool UpdateVolunteering(int id, Volunteering vol) 
        { 
            Volunteering original = GetVolunteeringById(id);
            if(original == default(Volunteering))
                return false;
            SetVolunteeringFields(original, vol);
        }
        public bool DeleteVolunteering(int id) 
        {
            Volunteering volunteering = GetVolunteeringById(id);
            if (volunteering == default(Volunteering))
                return false;
            _allVolunteerings.Remove(volunteering);
        }
        public bool AddFeedback(int id,int satisfactionLevel, string feedback) 
        {
            Volunteering volunteering = GetVolunteeringById(id);
            if (volunteering == default(Volunteering))
                return false;
            volunteering.Feedback = feedback;
            volunteering.SatisfactionLevel = satisfactionLevel;
            return true;
        }
    }
}
