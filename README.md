# queue-mgmt
basic library to handle queue

## A. Queue Data Model Request
1. ID (it will be the technical identifier (primary key) for the object in the queue)
2. Business ID: It is GUID for reference in the support operations.
3. Operation: Optional. it marks the queue operation
4. Reference Name
5. Reference Value
6. Data: xml or json
7. Created On : datetime. When the object in the queue created.
8. Modified On: datetime, When the object in the queue recently modified.
9. Status: lookup to identify at least the following statuses:
	9.a. Not Process
	9.b. Successfully Processed
	9.c. Skipped from Processing
	9.d. On Retry for Processing. It is optional, if the queue has the feature of retrying processing.
	9.e. Failed Processing
	9.f. Aborted processing
10. Remaining Retrial Counter: integer. It is optional, if the queue has the feature of retrying processing. It will start with the MAX retrial count. Then it will decrease by every retiral till it reaches zero, it will be marked as failed.
11. Next Retry On
12. Queue ID: integer. It is used to allow to run multiple processing tools on the same queue storage but every tool will run on a unique Queue ID objects. (Parallel handling to speed up queue processing). When adding objects in the queue, it should be added in round robin.

## B. Queue Data Model Settings
1. ID
2. Operation
3. Max Retrial Count
4. Retrial Delay: in seconds
5. Keep Succeeded Requests Duration: in days
6. Keep Failed Requests Duration: in days
7. Keep Not Processed Requests Duration: in days
8. Keep Skipped Requests Duration: in days
9. Keep Cancelled Requests Duration: in days
10. Keep Retrying Requests Duration: in days
11. Created On : datetime. When the object in the queue created.
12. Modified On: datetime, When the object in the queue recently modified.
