import {MinimalSchoolUser} from "../../../shared/models/minimal-school-user.interface";

export interface ClassViewModel {
    id: string;
    grade: number;
    gradeLetter: string;
    startYear: number;
    classTeacher: MinimalSchoolUser;
}