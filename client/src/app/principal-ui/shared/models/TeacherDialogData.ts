import {SchoolUsersTableData} from "./SchoolUsersTableData";
import {Subject} from "../../../teacher-ui/shared/models/subject";

export interface TeacherDialogData extends SchoolUsersTableData {
    subjects: Array<Subject>
    avgScore: number;
}