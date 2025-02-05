using HMS.Model;

public enum DepartmentType
{
    EmergencyMedicine,
    GeneralMedicine,
    Surgery,
    Pediatrics,
    ObstetricsGynecology,
    OrthopedicSurgery,
    Neurology,
    Cardiology,
    Psychiatry,
    Radiology,
    CardiovascularMedicine,
    GastroenterologyHepatology,
    Endocrinology,
    Oncology,
    PulmonaryMedicine,
    NephrologyHypertension,
    Rheumatology,
    Dermatology,
    HeartVascularThoracicInstitute,
    NeurologicalInstitute,
    OrthopaedicRheumatologicInstitute,
    DigestiveDiseaseSurgeryInstitute,
    CancerCenter,
    PediatricInstitute,
    EndocrinologyMetabolismInstitute,
    UrologyKidneyInstitute,
    RespiratoryInstitute,
    AnesthesiologyPainManagement,
    AnesthesiologyCriticalCareMedicine,
    Hematology,
    Otolaryngology,
    Neurosurgery,
    PediatricNeurology,
    TransplantSurgery
}

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Foreign Key to Hospital
    public int HospitalId { get; set; }
    public Hospital Hospital { get; set; }

    // Navigation property to doctors
    public ICollection<Doctor> Doctors { get; set; }

    // Enum property
    public DepartmentType Type { get; set; }
}