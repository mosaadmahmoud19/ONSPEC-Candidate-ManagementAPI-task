# Assumptions

1. The email address is a required and unique identifier for each candidate.

2. The API will be used internally and does not require authentication at this stage.

3. Only one preferred call time is stored per candidate.

4. LinkedIn and GitHub URLs are optional fields.

5. Free-text comments can contain any user input and are not validated.

6. The system assumes only one candidate per email exists in the database.

7. If a candidate with the provided email exists, their data is fully updated with the new request.

8. If the email does not exist, a new candidate record will be created.

9. No front-end integration is expected in this task.

10. The API is not expected to support GET/List endpoints at this stage — only POST is implemented.
