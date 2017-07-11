Feature: Scenarios
	In order to compare 2 xml files
	As a developer
	I want to be told the xml differences

@XmlPatchTool
Scenario Outline: Compare 2 XML files
	Given I use file <File>
	When I compare xml files
	Then the Node Changes should be <NodeChangesValue>
	And  the Attribute Changes should be <AttributeChangesValue>
	And  the Text Changes should be <ValueChangesValue>
	And  Changes flag should be <ChangesFlag>
Examples:
		| File					| NodeChangesValue  | AttributeChangesValue | ValueChangesValue		| ChangesFlag	|
		| NoChanges.xml			| 0					| 0						| 0						| false			|
#		| 1_NodeChange.xml		| 1					| 0						| 0						| true			|
#		| 1_AttributeChange.xml	| 0					| 1						| 0						| true			|
#		| 1_TextChange.xml		| 0					| 0						| 1						| true			|		


